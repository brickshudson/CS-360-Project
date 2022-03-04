using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameData : MonoBehaviour
{
    //public string GameName;
    public string DataStructureInfo;
    public string HowToPlay;

    private void Awake() {
        // Debug.Log(gameObject.scene.name + "\n" + HowToPlay + "\n" + DataStructureInfo);
        Zombie.MiniGameList.SetSceneData(gameObject.scene.name, HowToPlay, DataStructureInfo);
    }

}
