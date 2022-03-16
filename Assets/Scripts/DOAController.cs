using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GameLogging;
using UnityEngine.UI;

public class DOAController : MonoBehaviour
{
    public TMP_InputField Row;
    public TMP_InputField Col;
    public Button SubmitButton;

    public TextMeshProUGUI ErrorMessage;

    public TextMeshProUGUI[] People;

    public Text TVDisplay;

    HashSet<int> _numbers = new HashSet<int>();
    int[] Numbers;
    Queue<int> NumberQueue = new Queue<int>();

    Log Log = new Log();

    private void Awake() {
        
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
        }

        Numbers.Shuffle();
        for(int j = 0; j < Numbers.Length; j++) { NumberQueue.Enqueue(Numbers[j]); }
        TVDisplay.text = NumberQueue.Dequeue().ToString();

        ErrorMessage.gameObject.SetActive(false);
        SubmitButton.onClick.AddListener(Submit);
    }

    void Submit() {
        if (!string.IsNullOrEmpty(Row.text) && !string.IsNullOrEmpty(Col.text)) {
            string Coord = $"R{Row.text}C{Col.text}";
            Debug.Log(Coord);
            foreach (TextMeshProUGUI person in People) {
                if (person.name == Coord) {
                    if (person.text == TVDisplay.text) {
                        person.gameObject.transform.parent.gameObject.SetActive(false);
                        UpdateError(Errors.None);
                        TVDisplay.text = NumberQueue.Dequeue().ToString();
                        return;
                    } else {
                        Debug.Log(Errors.Invalid_Input);
                        UpdateError(Errors.Invalid_Input);
                        return;
                    }
                }
            }
            Debug.Log(Errors.Not_Correct);
            UpdateError(Errors.Not_Correct);
        } else { 
            UpdateError(Errors.No_Input);
            Debug.Log(Errors.No_Input);
        }
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
