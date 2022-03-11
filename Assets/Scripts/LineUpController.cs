//Written by The-Architect01
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameLogging;

public class LineUpController : MonoBehaviour
{
    public GameWin GameWinScreen;
    public GameLoss GameLoss;
    public CountDown CountDown;

    public Image Eyes;
    public Image Nose;
    public Image Mouth;
    public Composite[] Charges;

    public Face.Shape[] CorrectFace;
    public TextMeshProUGUI Characteristics;

    public Log GameLog;
    
    void Awake(){

        GameLog = new Log() {
            IsTeamGame = !Zombie.IsSolo,
            IsPractice = Zombie.IsPractice,
            Score = -1,
            TurnsUsed = 1,
        };

        CorrectFace = new Face.Shape[] {
            (Face.Shape)Random.Range(0,7),
            (Face.Shape)Random.Range(0,7),
            (Face.Shape)Random.Range(0,7),
        };

        foreach (Composite charge in Charges) {
            Face.Shape Eye = (Face.Shape)Random.Range(0, 7);
            Face.Shape Nose = (Face.Shape)Random.Range(0, 7);
            Face.Shape Mouth = (Face.Shape)Random.Range(0, 7);
            charge.Populate(Eye, Nose, Mouth, false);
        }

        int CorrectCharge = Random.Range(0, Charges.Length);
        Charges[CorrectCharge].Populate(CorrectFace[0], CorrectFace[1], CorrectFace[2], true);

        Eyes.sprite = Face.Eyes[(int)CorrectFace[0]];
        Nose.sprite = Face.Noses[(int)CorrectFace[1]];
        Mouth.sprite = Face.Mouths[(int)CorrectFace[2]];

        Characteristics.text = $"Eyes: {CorrectFace[0]}\nNose: {CorrectFace[1]}\n" +
            $"Mouth: {CorrectFace[2]}\n\nWanted For:\n"+
            "- Energy Consumption\n- Memory Leakage";

    }

    public void ChoiceMade(bool Correct) {
        if (!Correct) { GameLog.ErrorsMade++; /*Play Wrong Sound;*/ return; }
        //Play Correct Sound
        GameLog.Win = Correct;
        GameLog.TimeTaken = CountDown.TimeElapsed;
        CountDown.StopTimer();
        Zombie.CurrentProfileStats.Stats["Pointer"]["Police Line Up"].GameLog.Add(GameLog);
        if (Correct)
            GameWinScreen.Show();
        else
            GameLoss.Show();
    }

}
