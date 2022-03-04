using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SinglePlayerMenu : MonoBehaviour
{

    public Button OpenSingleplayerMenu; 
    // Start is called before the first frame update
    void Start()
    {
        OpenSingleplayerMenu.onClick.AddListener(delegate {
            SceneManager.LoadScene("SPCategoryMenu");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

