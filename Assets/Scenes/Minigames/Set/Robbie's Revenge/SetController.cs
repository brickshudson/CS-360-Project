//Written by The-Architect01
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class SetController : MonoBehaviour {

    public float RobbieDifficulty = .1f;

    public TMP_InputField PlayerInput;
    public TextMeshProUGUI SetType;
    public TextMeshProUGUI PlayerSet;

    public Animator RobbieSpeak;
    public TextMeshProUGUI RobbieTalk;
    bool RobbieFinished = false;
    public Sprite Robbie_Inactive;

    HashSet<string> Player = new HashSet<string>();

    HashSet<string> LegalOptions;
    List<string> IllegalOptions = new List<string>();

    public GameLoss Loss;
    public GameWin Win;
    public CountDown CountDown;

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

        int Location = LegalOptions.ContainsValue(PlayerInput.text);

        if (Location != -1) {
            if (Player.Add(LegalOptions.ElementAt(Location))) {
                LegalOptions.Remove(LegalOptions.ElementAt(Location));
                IllegalOptions.Add(LegalOptions.ElementAt(Location));

                string Last5 = "";
                for (int i = 1; i <= 5; i++) {
                    try {
                        Last5 += $"{i} {Player.ElementAt(Player.Count - i)}\n";
                    } catch {
                        Last5 += "\n";
                    }
                }

                PlayerSet.text = Last5;

                Debug.Log($"Legal {PlayerInput.text}");
                PlayerInput.Select();
            }
        } else {
            Debug.Log($"Illegal {PlayerInput.text}");
            Loss.Show();
            CountDown.StopTimer();
        }
        float RNG = Random.value;
        if (RNG >= RobbieDifficulty) {
            try {
                int RandomIndex = Random.Range(0, LegalOptions.Count - 1);
                StartCoroutine(RobbieSpeaking(LegalOptions.ElementAt(RandomIndex)));
                IllegalOptions.Add(LegalOptions.ElementAt(RandomIndex));
                LegalOptions.Remove(LegalOptions.ElementAt(RandomIndex));
                Debug.Log($"Legal {LegalOptions.ElementAt(RandomIndex)}");
            } catch {
                Win.Show();
                CountDown.StopTimer();
            }
        } else {
            int RandomIndex = Random.Range(0, IllegalOptions.Count-1);
            StartCoroutine(RobbieSpeaking(IllegalOptions.ElementAt(RandomIndex)));
            Debug.Log($"Illegal {IllegalOptions.ElementAt(RandomIndex)}");
            Win.Show();
            CountDown.StopTimer();
        }
    }

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
        RobbieTalk.text = "";
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
    
    static List<string> Sets = new List<string>();
    static Regex RegEx = new Regex("[^a-zA-Z0-9,]");

    static SetItems() {
        TextAsset[] Assets = Resources.LoadAll<TextAsset>("Set\\");
        foreach (TextAsset asset in Assets) { Sets.Add(asset.name); }
    }
    public static SetArgs SelectSet() {
        string Item = Sets[Random.Range(0, Sets.Count)];
        string[] LegalItems = Resources.Load<TextAsset>($"Set\\{Item}").text.Split(',');
        HashSet<string> Items = new HashSet<string>();
        foreach(string Legal in LegalItems) {
            Items.Add(Legal);
        }
        return new SetArgs(Item, Items);
    }

    public class SetArgs {
        public string Name { get; }
        public HashSet<string> Set { get; }
        public SetArgs(string Name, HashSet<string> Set) { this.Name = Name; this.Set = Set; }
    }

    public static int ContainsValue(this HashSet<string> Set, string valueCheck) {
        string CleanedCheck = RegEx.Replace(valueCheck.Normalize(System.Text.NormalizationForm.FormKD),"").ToLower();

        int counter = -1;
        foreach(string Item in Set) {
            counter++;
            string cleaned = RegEx.Replace(Item.Normalize(System.Text.NormalizationForm.FormKD),"").ToLower();
            if (cleaned == CleanedCheck)
                return counter;
        }
        return -1;
    }
}