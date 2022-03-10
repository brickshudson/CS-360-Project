//Written by The-Architect01
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour {

    #region Public Variables
    /// <summary><c>string</c> Stores the minigame to be loaded.</summary>
    public string MiniGame;
    /// <summary><c>TextMeshProUGUI</c> The label that will display the minigame's name.</summary>
    public TextMeshProUGUI GameName;
    /// <summary><c>TextMeshProUGUI</c> The label that will display how the minigame relates to the actual data structure.</summary>
    public TextMeshProUGUI DataStructure;
    /// <summary><c>TextMeshProUGUI</c> The label that will display how the minigame will play in relation to actual data structures.</summary>
    public TextMeshProUGUI HowTo;
    /// <summary><c>TMP_InputField</c> The user input that will display a team name. It also allows the user to input their own legal team name.</summary>
    public TMP_InputField TeamName;
    /// <summary><c>Button</c> The button that will transition and load the minigame. In multiplayer situations, it will send the <c>ready</c> message.</summary>
    public Button ReadyButton;
    /// <summary><c>TextMeshProUGUI</c> The label that will display the error message</summary>
    public TextMeshProUGUI ErrorText;
    /// <summary><c>Image</c> The image that will display the controls used in the minigame.</summary>
    public Image HowToPlay;
    /// <summary><c>Image</c> The image that will display a sneak peek of the minigame being played.</summary>
    public Image miniGame;
    #endregion

    #region Private Variables
    string RandomName;
    #endregion

    //GameHost GH = new GameHost();

    // Start is called before the first frame update
    void Start() {
        //Gets the Minigame
        if (!string.IsNullOrEmpty(Zombie.MiniGame)) { MiniGame = Zombie.MiniGame; }

        //Sets and shows the default team name.
        RandomName = TName.SelectRandomName();
        TeamName.text = RandomName;

        //Loads the sprites associated with minigame.
        HowToPlay.sprite = Resources.Load<Sprite>("How To/" + MiniGame);
        miniGame.sprite = Resources.Load<Sprite>("Minigame Snaps/" + MiniGame);

        //Hides the error text
        ErrorText.gameObject.SetActive(false);

        //After the textbox has been edited checks if the team name is legal
        TeamName.onEndEdit.AddListener(delegate {
            if (TeamName.text.Length > 12 || TeamName.text.Length < 4 || !TName.CheckLegality(TeamName.text) ||
                string.IsNullOrWhiteSpace(TeamName.text) || (TeamName.text.Length - Count(TeamName.text, ' ') < 4)) {
                TeamName.text = RandomName;
                ErrorText.gameObject.SetActive(true);
            } else {
                ErrorText.gameObject.SetActive(false);
            }
        });
        
        //Checks if the load screen has any errors and loads the minigame.
        ReadyButton.onClick.AddListener(delegate {
            if (ErrorText.gameObject.activeSelf) { return; }
            SceneManager.LoadScene(MiniGame);
        });

        //Uses the metadata to populate fields
        GameName.text = MiniGame;
        DataStructure.text = Zombie.MiniGameList.GetSceneDataStructureInfo(MiniGame);
        HowTo.text = Zombie.MiniGameList.GetSceneHowToPlay(MiniGame);

    }

    /// <summary>Counts the number of times the given string contains a value.</summary>
    /// <param name="text">The text to be searched through.</param>
    /// <param name="value">The value to be searched for.</param>
    /// <returns>The number of times the string contains that value.</returns>
    int Count(string text, char value) {
        int count = 0;
        foreach(char c in text.ToCharArray()) {
            if(c == value) { count++; }
        }
        return count;
    }

}
public struct TName {

    /// <summary>A list of adjectives to be used in team names.</summary>
    public static string[] TeamName1 = new string[] {
        "Cool",
        "Crazy",
        "Cozy",
        "Sneaky",
    };
    /// <summary>A list of nouns to be used in team names.</summary>
    public static string[] TeamName2 = new string[] {
        "Cat",
        "Tiger",
        "Dog",
        "Snake"
    };

    /// <summary>A list of words that cannot be used in team names.</summary>
    public static List<string> IllegalWords = new List<string>() { };

    /// <summary>Generates a random team name.</summary>
    /// <returns>The randomly generated team name.</returns>
    public static string SelectRandomName() {
        return TeamName1[UnityEngine.Random.Range(0, TeamName1.Length - 1)] + " " + TeamName2[UnityEngine.Random.Range(0, TeamName2.Length - 1)];
        //return "Homeless Penny";
    }

    /// <summary>Checks if a given team name is valid.</summary>
    /// <param name="TeamName">The team name being evaluated.</param>
    /// <returns><para><c>true</c> if legal and <c>false</c> if illegal.</para></returns>
    public static bool CheckLegality(string TeamName) {
        return true;
    }

}
