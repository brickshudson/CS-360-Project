using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayMenuChange : MonoBehaviour
{

    public Button OpenPlayMenu;
    // Start is called before the first frame update
    void Start()
    {
        OpenPlayMenu.onClick.AddListener(delegate {
            SceneManager.LoadScene("Play Menu");
        });
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
