using UnityEngine;
using UnityEngine.SceneManagement;

public class Zombie : MonoBehaviour {

    public static bool isSolo { get; set; } = true;
    private static bool created = false;

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
            //    Application.quitting += Quitting;
            DontDestroyOnLoad(gameObject);
            created = true;

            CurrentProfileStats = new PlayerStats();
            DiscordController = new DiscordController();
            MiniGameList = new MiniGameLister();

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
