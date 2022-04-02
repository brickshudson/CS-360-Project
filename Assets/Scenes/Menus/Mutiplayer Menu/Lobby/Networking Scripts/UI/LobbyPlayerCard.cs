using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

namespace LobbyUI
{
    public class LobbyPlayerCard : MonoBehaviour
    {
        [Header("Panels")]
        [SerializeField] private GameObject waitingForPlayerPanel;
        [SerializeField] private GameObject playerDataPanel;

        [Header("Data Display")]
        [SerializeField] private TMP_Text playerDisplayNameText;
        [SerializeField] private Toggle isReadyToggle;
        [SerializeField] private GameObject selectedCharacterImage;

        public void UpdateDisplay(LobbyPlayerState lobbyPlayerState)
        {
            playerDisplayNameText.text = lobbyPlayerState.PlayerName.ToString();
            isReadyToggle.isOn = lobbyPlayerState.IsReady;


            waitingForPlayerPanel.SetActive(false);
            playerDataPanel.SetActive(true);
        }

        public void DisableDisplay()
        {
            waitingForPlayerPanel.SetActive(true);
            playerDataPanel.SetActive(false);
        }
    }
}
