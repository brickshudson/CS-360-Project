//Written by The-Architect01
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zombie : MonoBehaviour {

    public static bool IsSolo { get; set; } = true;
    private static bool created = false;
    public static bool IsPractice { get; set; } = false;

    private static string _mg;
    public static string MiniGame { 
        get { 
            return _mg;
        } 
        set { 
            _mg = value; 
            DiscordController.ScreenName = _mg; 
        }
    }

    public static DiscordController DiscordController { get; private set; }
    public static PlayerStats CurrentProfileStats { get; private set; }
    public static MiniGameLister MiniGameList { get; private set; }

    private void Awake() { 
        if (!created) {
            // Application.quitting += Quitting;
            DontDestroyOnLoad(gameObject);
            created = true;

            DiscordController = new DiscordController();
            MiniGameList = new MiniGameLister();
            CurrentProfileStats = new PlayerStats();

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnApplicationQuit() {
        DiscordController.OnApplicationQuit();
    }

    private void Update() {
        DiscordController.Update();
    }
}