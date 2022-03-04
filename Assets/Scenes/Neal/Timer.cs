using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    /// <summary><c>TextMeshProUGUI</c> the label that will dynamically update.</summary>
    public TextMeshProUGUI TimerLabel;
    public bool AutoRun;

    // Start is called before the first frame update
    void Start()
    {
        TimerLabel.text = "00:00.000";
        if (AutoRun) { running = true; }
    }

    public float Time { get; set; }
    protected bool running;

    public void StopTimer() { running = false; }
    public void StartTimer() { running = true; }
    // Update is called once per frame
    /// <summary>Updates the timer element.</summary>
    protected virtual void Update()
    {
        if (running) {
            try {
                Time += UnityEngine.Time.deltaTime;
                float minutes = Mathf.FloorToInt(Time / 60);
                float seconds = Mathf.FloorToInt(Time % 60);
                float milliseconds = (Time % 1) * 1000;
                string timedisplay = $"{minutes,2}:{seconds,2}.{milliseconds,3:F0}";
                TimerLabel.text = timedisplay.Replace(" ", "0");
            } catch {
                running = false;
            }
        }
    }
}
