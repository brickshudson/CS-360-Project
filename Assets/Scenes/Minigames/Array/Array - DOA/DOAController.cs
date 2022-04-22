using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GameLogging;
using UnityEngine.UI;

public class DOAController : MonoBehaviour
{
    public GameWin GameWin;
    public GameLoss GameLoss;
    public CountDown CountDown;

    public TMP_InputField Row;
    public TMP_InputField Col;
    public Button SubmitButton;

    public TextMeshProUGUI ErrorMessage;

    public TextMeshProUGUI[] People;

    public Text TVDisplay;

    HashSet<int> _numbers = new HashSet<int>();
    int[] Numbers;
    Queue<int> NumberQueue = new Queue<int>();

    Log Log;

    private void Awake() {
        Row.Select();
        Log = new Log() {
            IsPractice = Zombie.IsPractice,
            IsTeamGame = !Zombie.IsSolo,
            ErrorsMade=0,
            TurnsUsed=0,
            TimeTaken=0,
        };

        Numbers = new int[16];

        int i = 0;
        while(_numbers.Count < Numbers.Length) {
            int R = Random.Range(10, 99);
            if (_numbers.Add(R)) {
                Numbers[i] = R;
                i++;
            }
        }
        Numbers.Shuffle();

        for(int j = 0; j < People.Length; j++) {
            People[j].text = Numbers[j].ToString();
            People[j].gameObject.transform.parent.GetComponent<Image>().sprite = Resources.Load<Sprite>($"DOA/Person{(Numbers[j]%8)+1}");
        }

        Numbers.Shuffle();
        for(int j = 0; j < Numbers.Length; j++) { NumberQueue.Enqueue(Numbers[j]); }
        TVDisplay.text = NumberQueue.Dequeue().ToString();

        ErrorMessage.gameObject.SetActive(false);
        SubmitButton.onClick.AddListener(Submit);
        Row.onEndEdit.AddListener(delegate { Col.Select(); });
        Col.onEndEdit.AddListener(delegate { SubmitButton.Select(); });
    }

    private void Update() {
        if (GameLoss.gameObject.activeInHierarchy) { 
            Log.Win = false;
        } else if (GameWin.gameObject.activeInHierarchy) { 
            Log.Win = true;
            Log.TimeTaken = CountDown.TimeElapsed;
        }
    }


    void Submit() {
        if (!string.IsNullOrEmpty(Row.text) && !string.IsNullOrEmpty(Col.text)) {
            string Coord = $"R{int.Parse(Row.text)}C{int.Parse(Col.text)}";
            Debug.Log(Coord);
            Col.text = "";
            Row.text = "";
            Row.Select();
            Log.TurnsUsed++;
            foreach (TextMeshProUGUI person in People) {
                if (person.name == Coord) {
                    if (person.text == TVDisplay.text) {
                        person.gameObject.transform.parent.gameObject.SetActive(false);
                        UpdateError(Errors.None);
                        try {
                            TVDisplay.text = NumberQueue.Dequeue().ToString();
                        } catch {
                            GameWin.Show();
                            Debug.Log("Win");
                        }
                        return;
                    } else {
                        Debug.Log(Errors.Invalid_Input);
                        UpdateError(Errors.Invalid_Input);
                        return;
                    }
                }
            }
            Log.ErrorsMade++;
            Debug.Log(Errors.Not_Correct);
            UpdateError(Errors.Not_Correct);
        } else {
            Log.ErrorsMade++;
            UpdateError(Errors.No_Input);
            Debug.Log(Errors.No_Input);
        }
        Col.text = "";
        Row.text = "";
        Row.Select();
    }

    void UpdateError(Errors error) {
        ErrorMessage.gameObject.SetActive(error != Errors.None);
        ErrorMessage.text = "Error " + error.ToString().Replace('_', ' ');
    }
 
    enum Errors {
        None,
        Invalid_Input,
        No_Input,
        Not_Found,
        Not_Correct,
        Over
    }

}
