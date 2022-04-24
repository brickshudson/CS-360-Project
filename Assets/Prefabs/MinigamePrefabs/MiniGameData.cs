using UnityEngine;

public class MiniGameData : MonoBehaviour {
    public string DataStructureInfo;
    public string HowToPlay;

    private void Awake() {
        Zombie.MiniGameList.SetSceneData(gameObject.scene.name, HowToPlay, DataStructureInfo);
    } 
}
