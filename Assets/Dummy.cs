using UnityEngine;
using UnityEngine.SceneManagement;
using Demo;
public class Dummy : MonoBehaviour {

    //static bool _Active;
    //public static bool IsActive { get { return _Active; } set { _Active = value; ShowBoard(); } }

    public static void ShowBoard() {
        Debug.LogWarning($"Test Working");
        //AsyncOperation Load = SceneManager.LoadSceneAsync("MainMenu");
        //SceneManager.LoadScene("Board");
    }

    private void Update() {
        if (ICheckState.FireEvent) { OnDisable(); }
    }

    void OnDisable() {
        ShowBoard();
    }
}
namespace Demo {
    public static class ICheckState {
        public static bool FireEvent;

    }
}