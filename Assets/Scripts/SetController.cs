using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Reflection;
using System.Linq;
using UnityEngine.UI;

public class SetController : MonoBehaviour {

    public float RobbieDifficulty = .1f;

    public TMP_InputField PlayerInput;
    public TextMeshProUGUI SetType;
    public TextMeshProUGUI PlayerSet;

    public Animator RobbieSpeak;
    public TextMeshProUGUI RobbieTalk;
    public Sprite Robbie_Inactive;

    HashSet<string> Player = new HashSet<string>();

    HashSet<string> LegalOptions;
    List<string> IllegalOptions = new List<string>();

    // Start is called before the first frame update
    void Start() {
        RobbieSpeak.enabled = false;
        SetItems.SetArgs GameLoad = SetItems.SelectSet();
        LegalOptions = GameLoad.Set;
        SetType.text = $"Topic: {GameLoad.Name}";

        PlayerSet.text = "";

        PlayerInput.onEndEdit.AddListener(delegate {
            PlayerMove();
        });
        PlayerInput.Select();
    }

    void PlayerMove() {
        if(string.IsNullOrWhiteSpace(PlayerInput.text) || string.IsNullOrWhiteSpace(PlayerInput.text)) { PlayerInput.text = ""; PlayerInput.Select(); return; }
        if (LegalOptions.Contains(PlayerInput.text.ToLower())) {
            if (Player.Add(PlayerInput.text.ToLower())) {
                LegalOptions.Remove(PlayerInput.text.ToLower());
                IllegalOptions.Add(PlayerInput.text.ToLower());

                string Last5 = "";
                for(int i = 1; i <= 5; i++) {
                    try {
                        Last5 += $"{i} {Player.ElementAt(Player.Count - i)}\n";
                    } catch {
                        Last5 += "\n";
                    }
                }

                PlayerSet.text = Last5;

                Debug.Log($"Legal {PlayerInput.text}");
            } 
        } else {
            Debug.Log($"Illegal {PlayerInput.text}");
        }
        float RNG = Random.value;
        if (RNG >= RobbieDifficulty) {
            int RandomIndex = Random.Range(0, LegalOptions.Count);
            StartCoroutine(RobbieSpeaking(LegalOptions.ElementAt(RandomIndex)));
            IllegalOptions.Add(LegalOptions.ElementAt(RandomIndex));
            LegalOptions.Remove(LegalOptions.ElementAt(RandomIndex));
            Debug.Log($"Legal {LegalOptions.ElementAt(RandomIndex)}");
        } else {
            int RandomIndex = Random.Range(0, IllegalOptions.Count);
            StartCoroutine(RobbieSpeaking(IllegalOptions.ElementAt(RandomIndex)));
            Debug.Log($"Illegal {IllegalOptions.ElementAt(RandomIndex)}");
        }
    }

    bool RobbieFinished = false;

    private void Update() {
        if(Input.GetKey(KeyCode.Return) && RobbieFinished) {
            RobbieFinished = false;
            RobbieTalk.transform.parent.gameObject.SetActive(false);
            RobbieTalk.text = "";
            RobbieSpeak.enabled = false;
            RobbieSpeak.gameObject.GetComponent<Image>().sprite = Robbie_Inactive;
            
            PlayerInput.text = "";
            PlayerInput.enabled = true;
            PlayerInput.Select();
        }
    }

    IEnumerator RobbieSpeaking(string Word) {
        PlayerInput.enabled = false;
        RobbieFinished = false;
        RobbieSpeak.enabled = true;
        RobbieTalk.transform.parent.gameObject.SetActive(true);
        foreach (char C in Word.ToCharArray()) {
            RobbieTalk.text += C;
            yield return new WaitForSeconds(.1f);
            RobbieFinished = true;
        }
    }

}
public static class SetItems {
    #region Add Below Me -- Note: All Variables below should be marked as only static!
    static HashSet<string> Foods_Starting_With_C = new HashSet<string>(){"cabbage","cake","carrots","carne asada","celery","cheese",
        "chicken","catfish","chips","chocolate","chowder","clams","coffee","cookies","corn","cupcakes","crab","curry","cereal"};
    #endregion
    #region Don't Edit
    public static SetArgs SelectSet() {
        FieldInfo[] LegalSets = typeof(SetItems).GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        int Ran = Random.Range(0, LegalSets.Length);
        return new SetArgs(LegalSets[Ran].Name.Replace('_',' '), (HashSet<string>)LegalSets[Ran].GetValue(typeof(SetItems)));
    }

    public struct SetArgs {
        public string Name { get; }
        public HashSet<string> Set { get; }
        public SetArgs(string Name, HashSet<string> Set) { this.Name = Name; this.Set = Set; }
    }
    #endregion
}