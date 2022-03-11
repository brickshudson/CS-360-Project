using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    public Button BackButton;
    // Start is called before the first frame update
    void Start()
    {
        BackButton.onClick.AddListener(delegate {
            SceneManager.LoadScene("Play Menu");
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
