using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyCreation : MonoBehaviour
{
    public Button OpenMultiplayerMenu;
    // Start is called before the first frame update
    void Start()
    {
        OpenMultiplayerMenu.onClick.AddListener(delegate {
            SceneManager.LoadScene("Scene_Menu");
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
