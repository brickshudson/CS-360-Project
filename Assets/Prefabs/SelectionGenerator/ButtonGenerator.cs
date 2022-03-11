using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonGenerator : MonoBehaviour
{
    public enum SelectionType
    {
        Category = 0,
        Scene = 1,
    };

    public string NextScene;
    public SelectionType selectionType;
    public GameObject buttonPrefab;

    public SelectionButtonScript.Callback callback;

    private string[] options;

    void Start()
    {
        // Set the options and callback based on the chosen selection type
        if(selectionType == SelectionType.Category)
        {
            // Get a list of minigame categories
            options = Zombie.MiniGameList.GetListofCategories();
            callback = (selection) =>
            {
                //Debug.Log("Category Selected: " + selection);

                // Set the current category to the selected one and load the next scene
                Zombie.MiniGameList.CurrentCategory = selection;
                SceneManager.LoadScene(NextScene);
            };
        }
        else if(selectionType == SelectionType.Scene)
        {
            options = Zombie.MiniGameList.GetCurrentScenes();
            callback = (selection) => 
            {
                //Debug.Log("Selection made: " + selection);

                // Update Zombie for the chosen minigame and load the next scene
                Zombie.MiniGame = selection;
                Zombie.IsSolo = true;
                SceneManager.LoadScene(NextScene);
            };
        }

        // Get the height and width of the field for buttons
        float height = GetComponent<RectTransform>().sizeDelta.y;
        float width =  GetComponent<RectTransform>().sizeDelta.x;

        // Calculate the spacing for the buttons and the position of the top button
        float delta = height / options.Length;
        Vector3 position = new Vector3(0, height / 2, 0);

        foreach(string opt in options)
        {
            // Create a new button for the option and initialize its position and size
            GameObject newButton = Instantiate(buttonPrefab, position, Quaternion.identity);
            newButton.transform.SetParent(transform, false);
            newButton.GetComponent<RectTransform>().sizeDelta = new Vector2(width, width / 5);

            // Set up the selection and callback for the button
            newButton.GetComponent<SelectionButtonScript>().selectionData = opt;
            newButton.GetComponent<SelectionButtonScript>().callback = callback;

            // Update the position for the next button
            position = new Vector3(0, position.y - delta, 0);
        }
    }
}
