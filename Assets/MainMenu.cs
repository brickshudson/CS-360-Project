using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button StartGame;
  //  public Button QuitGame;
    public string MiniGame;
    
    // Start is called before the first frame update
    void Start()
    {
        StartGame.onClick.AddListener(delegate {
            Zombie.MiniGame = MiniGame;
            Zombie.isSolo = true;
            SceneManager.LoadScene("Load Game");
        });

        /*QuitGame.onClick.AddListener(delegate {
            Application.Quit();
        });*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
