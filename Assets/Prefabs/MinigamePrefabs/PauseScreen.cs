using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour {
    public Timer Timer;
    public Button Restart;
    public Button Resume;
    public Button MainMenu;

    public GameObject Host;
    public GameObject Game;

    public KeyCode PauseKey;

    private enum PauseState : ushort {
        NotPaused,
        StartPause,
        Paused,
        EndPause,
        EPS_StateCount
    }

    private PauseState currentPauseState = PauseState.NotPaused;

    private void Awake() {
        Restart.onClick.AddListener(delegate {
            Debug.Log("Restart Clicked");
            SceneManager.LoadScene(gameObject.scene.name);
        });
        Resume.onClick.AddListener(delegate {
            Debug.Log("Resume Clicked");
        });
        MainMenu.onClick.AddListener(delegate {
            Debug.Log("Main Menu Clicked");
            SceneManager.LoadScene("SPCategoryMenu");
        });
    }

    public void ResumePressed() {
        currentPauseState = PauseState.EndPause;
        UpdatePauseMenu();
    }

    // Update is called once per frame
    void Update() {

        if (Game.activeInHierarchy) { return; }

        // If the key is PRESSED, and was NOT pressed last frame -> Update State
        // If the key is RELEASED, and was pressed last frame -> Update State

        // How this if statement was reduced:
        // if((Input.GetKeyDown(PauseKey) && currentPauseState % 2 == 0) || (!Input.GetKeyDown(PauseKey)  && currentPauseState % 2 != 0))
        // if(Input.GetKeyDown(PauseKey) ? currentPauseState % 2 == 0 : currentPauseState % 2 != 0)
        if(Input.GetKeyDown(PauseKey) == ((int)currentPauseState % 2 == 0)) {
            currentPauseState = (PauseState)(((int)currentPauseState + 1) % (int)PauseState.EPS_StateCount);

            UpdatePauseMenu();
        }
    }

    private void UpdatePauseMenu() { 

        switch(currentPauseState) {
            // When the pause starts, show the pause screen and stop the countdown timer
            case PauseState.StartPause:
                Timer.StopTimer();
                Host.SetActive(true);
                break;
                
            // When the pause ends, disable the pause overlay and start the timer from where it was
            case PauseState.EndPause:
                Timer.StartTimer();
                Host.SetActive(false);
                break;

            default:
                break;
        }
    }
}
