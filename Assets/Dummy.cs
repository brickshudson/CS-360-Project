using LobbyRelaySample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Locator.Get.Messenger.OnReceiveMessage(MessageType.ChangeMenuState, GameState.JoinMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
