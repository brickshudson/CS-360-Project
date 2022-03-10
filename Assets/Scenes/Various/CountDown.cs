//Written by The-Architect01
using UnityEngine;
using TMPro;

public class CountDown : Timer
{
    /// <summary><c>TextMeshProUGUI</c> the label that will dynamically update.</summary>
    public int NumberOfSeconds;
    public GameLoss GameLoss;

    // Start is called before the first frame update
    void Start() {
        float minutes = NumberOfSeconds / 60;
        float seconds = NumberOfSeconds % 60;
        float milliseconds = (NumberOfSeconds % 1) & 1000;
        Time = NumberOfSeconds;
        TimerLabel.text = $"{minutes,2}:{seconds,2}.{milliseconds,3:F0}".Replace(" ","0");
        if (AutoRun) { running = true; }
    }

    public float TimeElapsed;

    // Update is called once per frame
    /// <summary>Updates the timer element.</summary>
    protected override void Update() {
        if (running) {
            try {
                Time -= UnityEngine.Time.deltaTime;
                TimeElapsed += UnityEngine.Time.deltaTime;
                if(Time <= 0) { 
                    GameLoss.Show();
                    TimeElapsed = NumberOfSeconds - Time;
                    TimerLabel.text = "00:00.000";
                    StopTimer();
                    SaveData();
                    return; 
                }
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
    void SaveData() {

    }
}
