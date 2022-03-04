using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public Button OpenOptions;

    // Start is called before the first frame update
    void Start()
    {
        OpenOptions.onClick.AddListener(delegate {
            SceneManager.LoadScene("Main Menu");
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
