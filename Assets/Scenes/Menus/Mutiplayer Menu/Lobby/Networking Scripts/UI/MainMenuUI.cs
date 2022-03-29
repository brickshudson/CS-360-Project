using LobbyNetworking;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Lobby
{
    public class MainMenuUI : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMP_InputField displayNameInputField;

        private void Start()
        {
            PlayerPrefs.GetString("PlayerName");

        }

        public void OnHostClicked()
        {

            GameNetPortal.Instance.StartHost();
        }

        public void OnClientClicked()
        {

            PlayerPrefs.SetString("PlayerName", displayNameInputField.text);

            ClientGameNetPortal.Instance.StartClient();
        }
    }
}

