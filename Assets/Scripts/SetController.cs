//Written by The-Architect01
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
    static List<string> Sets = new List<string>() { "Pokemon" };
    static HashSet<string> Foods_Starting_With_C = new HashSet<string>(){ "cabbage","cake","carrot","carne asada","celery","cheese",
        "chicken","catfish","chip","chocolate","chowder","clam","coffee","cookie","corn","cupcakes","crab","curry","cereal", "candy" };

    static HashSet<string> Countries = new HashSet<string>() { "afghanistan", "albania", "algeria", "andorra", "angola", "antigua and barbuda", "argentina", "armenia", "australia",
        "austria", "azerbaijan", "bahamas", "bahrain", "bangladesh", "barbados", "belarus", "belgium", "belize", "benin", "bhutan", "bolivia", "bosnia and herzegovina", "botswana", 
"brazil", "brunei", "bulgaria", "burkina faso", "burundi", "côte d'ivoire", "cabo verde", "cambodia", "cameroon", "canada", "central african republic", "chad", "chile", "china", 
"colombia", "comoros", "congo", "costa rica", "croatia", "cuba", "cyprus", "czech republic", "democratic republic of the congo", "denmark", "djibouti", "dominica", "dominican republic",
        "ecuador", "egypt", "el salvador", "equatorial guinea", "eritrea", "estonia", "eswatini", "ethiopia", "fiji", "finland", "france", "gabon", "gambia", "georgia", "germany", 
"ghana", "greece", "grenada", "guatemala", "guinea", "guinea-bissau", "guyana", "haiti", "holy see", "honduras", "hungary", "iceland", "india", "indonesia", "iran", "iraq", "ireland",
        "israel", "italy", "jamaica", "japan", "jordan", "kazakhstan", "kenya", "kiribati", "kuwait", "kyrgyzstan", "laos", "latvia", "lebanon", "lesotho", "liberia", "libya", 
"liechtenstein", "lithuania", "luxembourg", "madagascar", "malawi", "malaysia", "maldives", "mali", "malta", "marshall islands", "mauritania", "mauritius", "mexico", 
"micronesia", "moldova", "monaco", "mongolia", "montenegro", "morocco", "mozambique", "myanmar", "namibia", "nauru", "nepal", "netherlands", "new zealand", "nicaragua", "niger", 
"nigeria", "north korea", "north macedonia", "norway", "oman", "pakistan", "palau", "palestine state", "panama", "papua new guinea", "paraguay", "peru", "philippines", "poland", 
"portugal", "qatar", "romania", "russia", "rwanda", "saint kitts and nevis", "saint lucia", "saint vincent and the grenadines", "samoa", "san marino", "sao tome and principe", "saudi arabia",
        "senegal", "serbia", "seychelles", "sierra leone", "singapore", "slovakia", "slovenia", "solomon islands", "somalia", "south africa", "south korea", "south sudan", "spain", "sri lanka",
        "sudan", "suriname", "sweden", "switzerland", "syria", "tajikistan", "tanzania", "thailand", "timor-leste", "togo", "tonga", "trinidad and tobago", "tunisia", "turkey", 
"turkmenistan", "tuvalu", "uganda", "ukraine", "united arab emirates", "united kingdom", "united states of america", "uruguay", "uzbekistan", "vanuatu", "venezuela", "vietnam", "yemen",
        "zambia", "zimbabwe" };

    static HashSet<string> States = new HashSet<string>() { "alabama", "alaska", "arizona", "arkansas", "california", "colorado", "connecticut", "delaware", "florida", "georgia", 
"hawaii", "idaho", "illinois", "indiana", "iowa", "kansas", "kentucky", "louisiana", "maine", "maryland", "massachusetts", "michigan", "minnesota", "mississippi", "missouri", "montana",
        "nebraska", "nevada", "new hampshire", "new jersey", "new mexico", "new york", "north carolina", "north dakota", "ohio", "oklahoma", "oregon", "pennsylvania", "rhode island", 
"south carolina", "south dakota", "tennessee", "texas", "utah", "vermont", "virginia", "washington", "west virginia", "wisconsin", "wyoming" };

    
    #endregion
    #region Don't Edit
    public static SetArgs SelectSet() {
        string Item = Sets[Random.Range(0, Sets.Count)];
        string[] LegalItems = Resources.Load<TextAsset>("/Set/Pokemon").text.Split(',');
        HashSet<string> Items = new HashSet<string>();
        foreach(string Legal in LegalItems) { Items.Add(Legal); }
        return new SetArgs(Item, Items);
    }

    public struct SetArgs {
        public string Name { get; }
        public HashSet<string> Set { get; }
        public SetArgs(string Name, HashSet<string> Set) { this.Name = Name; this.Set = Set; }
    }
    #endregion
}