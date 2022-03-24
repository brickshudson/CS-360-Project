using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    public Timer Timer;
    public Button Restart;
    public Button Resume;
    public Button MainMenu;

    public GameObject Host;

    public KeyCode PauseKey;
    public KeyCode ResumeKey;

    private void Awake() {
        Restart.onClick.AddListener(delegate { Debug.Log("Restart Clicked"); });
        Resume.onClick.AddListener(delegate { Debug.Log("Resume Clicked"); });
        MainMenu.onClick.AddListener(delegate { Debug.Log("Main Menu Clicked"); });
    }

    // Update is called once per frame
    void Update() {
        if (PauseKey == ResumeKey) {
            if (Timer.running) { Timer.StopTimer(); }else { Timer.StartTimer(); }
            Host.SetActive(!gameObject.activeInHierarchy);
        } else {
            if (Input.GetKeyDown(PauseKey)) {
                Timer.StopTimer();
                Host.SetActive(true);
                return;
            } else if (Input.GetKeyDown(ResumeKey)) {
                Timer.StartTimer();
                Host.SetActive(false);
                return;
            }
        }
    }
}
