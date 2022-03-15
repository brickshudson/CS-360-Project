using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackScript : MonoBehaviour
{
    public Button BackButton;
    // Start is called before the first frame update
    void Start()
    {
        BackButton.onClick.AddListener(delegate {
            SceneManager.LoadScene("Multiplayer");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
