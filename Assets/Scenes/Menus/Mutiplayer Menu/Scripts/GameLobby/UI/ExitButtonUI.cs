using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace LobbyRelaySample.UI
{
    /// <summary>
    /// When the main menu's Exit button is selected, send a quit signal.
    /// </summary>
    public class ExitButtonUI : MonoBehaviour
    {
        public Button exitLobby;

        public void OnExitButton()
        {
            exitLobby.onClick.AddListener(delegate {
                SceneManager.LoadScene("Play Menu");
            });
        }
    }
}
