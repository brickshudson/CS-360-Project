using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameLister
{
    // MGLScene holds all data for the 
    private class MGLScene
    {
        // Infomation derived from the SceneManager
        // path = "Assets/Scenes/type/category/.../name.unity"
        // (... holds any number of intermediate folders that won't be used in the lister)
        public string path = "";
        public string name = "";
        public string type = "";
        public string category = "";
        public int index = -1;

        // Information gained from loading Minigames for data
        public string howToPlay = "";
        public string dataStructureInfo = "";

        public string toString()
        {
            string output = "Index: " + index + " Path: " + path + "\n";
            output += "Level Name: " + name + "\n";
            output += "Level Type: " + type + "\n";
            output += "Level Category: " + category + "\n";
            output += "How to play: " + howToPlay + "\n";
            output += "Datastructure Info: " + dataStructureInfo + "\n";

            return output;
        }

    }

    // A list of all scenes in the build
    private static MGLScene[] scenes = null;

    // The major type of levels to search
    public string desiredType = "Minigames";
    private ArrayList desiredTypeList = null;

    // All the scenes of the desired type, divided into their subcategories
    private string[] givenCategories = null;
    private ArrayList[] categoryLists = null;

    // The currently selected category (eventually, allow for a set of categories)
    private int _currentCategory;
    public string CurrentCategory{get{return givenCategories[_currentCategory];} set{_currentCategory = LookupCategory(value);} }

    public MiniGameLister()
    {
        // Generate a list of every scene in the build
        CaptureScenes();

        // Generate a list of the categories and categorize the scenes
        GenerateCategories();

        // Load each minigame to prepare their data for the Load Screen
        PrepareMinigameData(desiredType);

        _currentCategory = -1;
    }
    
    public void SetSceneData(string sceneName, string sceneHowToPlay, string sceneDataStructureInfo)
    {
        int i = LookupScene(sceneName);

        if(i != -1)
        {
            // Updates the scene with the Minigame Data
            scenes[i].howToPlay = sceneHowToPlay;
            scenes[i].dataStructureInfo = sceneDataStructureInfo;
        }
    }

    public string GetSceneHowToPlay(string sceneName)
    {
        int i = LookupScene(sceneName);

        if(i != -1)
            return scenes[i].howToPlay;

        return "";
    }

    public string GetSceneDataStructureInfo(string sceneName)
    {
        int i = LookupScene(sceneName);

        if(i != -1)
            return scenes[i].dataStructureInfo;

        return "";
    }

    public string[] GetCurrentScenes()
    {
        return GetSceneNamesFromCategory(_currentCategory);
    }

    public string[] GetListofCategories()
    {
        // Returns a list of all categories (eg. data structures)
        return givenCategories;
    }

    public void unsetCurrentCategory()
    {
        // Remove the category selection
        _currentCategory = -1;
    }

    public string GetCategoryFromSceneName(string sceneName)
    {
        int i = LookupScene(sceneName);

        if(i != -1) // Find the scene and return its category
            return scenes[i].category;

        return "";
    }
    
    public string[] GetSceneNamesFromCategory(int sceneListIndex)
    {
        ArrayList levels = new ArrayList();

        // If no scene is given, find all scenes with the type
        if(sceneListIndex == -1)
        {
            foreach(MGLScene scene in scenes)
                if(scene.type.Equals(desiredType))
                    levels.Add(scene.name);
        }
        else // Find all the scenes in the given category
            foreach(int index in categoryLists[sceneListIndex])
                levels.Add(scenes[index].name);

        return (string[])levels.ToArray(typeof(string));
    }
    public string[] GetSceneNamesFromCategory(string CategoryName) {
        return GetSceneNamesFromCategory(LookupCategory(CategoryName));
    }

    private void CaptureScenes()
    {
        if(scenes == null) // Generate all scenes in the build
        {
            var sceneNumber = SceneManager.sceneCountInBuildSettings;
            scenes = new MGLScene[sceneNumber];

            // Build a regex to capture important data from the path of the scene
            Regex r = new Regex(@"Assets\/Scenes\/(?<type>[^\/]+)\/(?<category>[^\/]+)((\/[^\/]+))?\/(?<name>[^\/]+).unity");

            // Generate a list of all scenes in the build
            for(int i = 0; i < scenes.Length; ++i)
            {
                scenes[i] = new MGLScene();
                scenes[i].index = i;
                scenes[i].path = SceneUtility.GetScenePathByBuildIndex(i);
            
                // Check the path against the regex
                Match match = r.Match(scenes[i].path);
                if(match.Success)
                {
                    // If the path was correctly formatted, record the values captured from the path
                    scenes[i].type =    match.Groups["type"].Value;
                    scenes[i].category = match.Groups["category"].Value;
                    scenes[i].name =    match.Groups["name"].Value;
                }

                //Debug.Log(scenes[i].toString());
            }
        }
    }

    private void GenerateCategories()
    {
        // Generate a set of categories for the given type
        HashSet<string> categories = new HashSet<string>();
        foreach(MGLScene s in scenes)
            if(s.type.Equals(desiredType))
                categories.Add(s.category);

        // Using the set, generate a sorted list of the categories
        givenCategories = new string[categories.Count];
        categories.CopyTo(givenCategories);
        Array.Sort(givenCategories, 0, givenCategories.Length);

        // Create the category lists
        desiredTypeList = new ArrayList();
        categoryLists = new ArrayList[givenCategories.Length];
        for(int i = 0; i < givenCategories.Length; ++i)
            categoryLists[i] = new ArrayList();

        // Put each scene in the appropriate categoryList
        foreach(MGLScene s in scenes)
            if(s.type.Equals(desiredType))
            {
                desiredTypeList.Add(s.index);

                for(int i = 0; i < givenCategories.Length; ++i)
                    if(s.category.Equals(givenCategories[i]))
                    {
                        categoryLists[i].Add(s.index);
                        break;
                    }
            }
        
        /*for(int i = 0; i < givenCategories.Length; ++i)
            Debug.Log(givenCategories[i] + ": " + categoryLists[i].Count);*/
    }

    private void PrepareMinigameData(string sceneType)
    {
        // For all minigames, load and unload the scene to generate the minigame data
        foreach(MGLScene s in scenes)
            if(s.type.Equals(sceneType))
            {
                SceneManager.LoadScene(s.name, LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync(s.name);
            }
    }

    private int LookupScene(string sceneName)
    {
        // Find the scene index from the scene name
        for(int i = 0; i < scenes.Length; ++i)
            if(scenes[i].name.Equals(sceneName))
                return i;

        return -1;
    }

    private int LookupCategory(string category)
    {
        // Find the category index from the category name
        for(int i = 0; i < givenCategories.Length; ++i)
            if(category.Equals(givenCategories[i]))
                return i;

        return -1;
    }

    public string randomMinigame()
    {
        int minigameIndex = UnityEngine.Random.Range(0, desiredTypeList.Count);
        int sceneIndex = (int)desiredTypeList[minigameIndex];

        return scenes[sceneIndex].name;
    }
}
