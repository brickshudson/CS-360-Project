//Written by The-Architect01
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStart : MonoBehaviour{
    public Image Display;
    public TextMeshProUGUI Title;
    public TextMeshProUGUI CountDown;
    public int CountDownDuration = 4;
    public Timer Timer;

    // Start is called before the first frame update
    void Start() {
        CountDown.text = CountDownDuration.ToString();
        StartCoroutine(CountDownFire());
    }

    IEnumerator CountDownFire() {
        while (CountDownDuration > 0) {
            CountDownDuration--;
            CountDown.text = CountDownDuration.ToString();
            
            if(CountDownDuration == 0) { CountDown.text = "GO!"; }
            yield return new WaitForSeconds(1f);
        }
        Display.gameObject.SetActive(false);
        Title.gameObject.SetActive(false);
        CountDown.gameObject.SetActive(false);
        Timer.StartTimer();
    }

}
