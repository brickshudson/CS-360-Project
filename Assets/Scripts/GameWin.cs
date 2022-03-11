//Written by The-Architect01
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameWin : MonoBehaviour
{
    #region Public Variables
    public Timer Timer;
    public Image Screen;
    public TextMeshProUGUI TimeWin;
    public TextMeshProUGUI Win;

    public Button Retry;
    public Button Next;

    public float DisplayDelay = .02f;
    public bool DetectWin { get; set; } = false;
    #endregion
    private CanvasGroup group;

    //Hides the screen
    private void Awake() {
        Screen.gameObject.SetActive(false);
        TimeWin.gameObject.SetActive(false);
        Win.gameObject.SetActive(false);
        group = GetComponent<CanvasGroup>();
        group.alpha = 0f;
    }

    private void Start() {
        if (!Zombie.IsSolo) { Retry.enabled = false; Next.transform.position = new Vector3(0f, -250f, 0f); }
        Retry.onClick.AddListener(Retry_OnClick);
        Next.onClick.AddListener(Next_OnClick);
    }

    //Shows the screen
    public void Show() {
        DetectWin = true;
        Invoke(nameof(ShowGameOver), DisplayDelay);
    }

    //Makes it look nice
    private void ShowGameOver() {
        TimeWin.text = Timer is CountDown ? 
            $"Time: {((CountDown)Timer).TimeElapsed}" :
            $"Time: {Timer.TimerLabel.text}";

        float alphacounter = 0f;
        Screen.gameObject.SetActive(true);
        TimeWin.gameObject.SetActive(true);
        Win.gameObject.SetActive(true);
        while (group.alpha < 1f) {
            alphacounter += .001f;
            group.alpha = alphacounter;
        }
    }

    private void Retry_OnClick() {

    }
    private void Next_OnClick() {

    }
}
