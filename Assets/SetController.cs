using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Reflection;

public class SetController : MonoBehaviour {

    public float RobbieDifficulty = .1f;

    public TMP_InputField PlayerInput;
    public TextMeshProUGUI SetType;
    public TextMeshProUGUI PlayerSet;

    HashSet<string> Player;

    HashSet<string> LegalOptions;
    List<string> IllegalOptions;

    // Start is called before the first frame update
    void Start() {

        SetItems.SetArgs GameLoad = SetItems.SelectSet();
        LegalOptions = GameLoad.Set;
        SetType.text = $"Topic: {GameLoad.Name}";

        PlayerInput.onEndEdit.AddListener(delegate {
            PlayerMove();
        });
    }

    void PlayerMove() {
        if (LegalOptions.Contains(PlayerInput.text)) {
            if (Player.Add(PlayerInput.text)) {
                LegalOptions.Remove(PlayerInput.text);
                IllegalOptions.Add(PlayerInput.text);
                Debug.Log("Legal");
            } else {
                Debug.Log("Illegal");
            }
        }
        float RNG = Random.value;
        if (RNG >= RobbieDifficulty) {
            int RandomIndex = Random.Range(0, LegalOptions.Count);
            Debug.Log("Legal");
        } else {
            Debug.Log("Illegal");
        }
    }

}
public static class SetItems {
    #region Add Below Me -- Note: All Variables below should be marked as only static!
    static HashSet<string> Items = new HashSet<string>(){ "Test"};
    #endregion
    #region Don't Edit
    public static SetArgs SelectSet() {
        FieldInfo[] LegalSets = typeof(SetItems).GetFields(BindingFlags.Static);
        int Ran = Random.Range(0, LegalSets.Length - 1);
        return new SetArgs(LegalSets[Ran].Name, (HashSet<string>)LegalSets[Ran].GetValue(typeof(SetItems)));
    }

    public struct SetArgs {
        public string Name { get; }
        public HashSet<string> Set { get; }
        public SetArgs(string Name, HashSet<string> Set) { this.Name = Name; this.Set = Set; }
    }
    #endregion
}