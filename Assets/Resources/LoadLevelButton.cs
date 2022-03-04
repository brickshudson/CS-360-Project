using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevelButton : MonoBehaviour
{
    public string LevelToLoad;

    void Start()
    {
        // If the button text is empty, fill it with the level name
        if(GetComponentInChildren<TMPro.TextMeshProUGUI>().text.Equals(""))
            GetComponentInChildren<TMPro.TextMeshProUGUI>().text = LevelToLoad;

        // When clicked, load the next level
        GetComponent<Button>().onClick.AddListener(delegate
        {
                // Debug.Log("Level loading: " + LevelToLoad);
                SceneManager.LoadScene(LevelToLoad);
        });
    }
}
