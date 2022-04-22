//Written by The-Architect01
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TOHTower : MonoBehaviour {

    public List<TowerPart> Tower = new List<TowerPart>();
    public bool IsCorrect;
    public static int TurnsTaken = 0;
    public TextMeshProUGUI TurnsTakenDisplay;
    public GameWin WinGame;

    public void Start() { TurnsTaken = 0; }

    public void OnClick() {
        if(TowerPart.Selected == null) { return; }
        if (Tower.Contains(TowerPart.Selected)) { TowerPart.Selected = null;  return; }

        int LocationAdded = 1;
        foreach (TowerPart TP in Tower) {
            LocationAdded++;
            if (TP.Rank < TowerPart.Selected.Rank) { TowerPart.Selected = null; ShowError(); return; }
        }

        TurnsTaken++;
        TurnsTakenDisplay.text = $"Moves Taken: {TurnsTaken}";
        Tower.Add(TowerPart.Selected);

        TowerPart.Selected.Tower.Tower.Remove(TowerPart.Selected);
        
        try {
            for (int i = 0; i < TowerPart.Selected.Tower.Tower.Count; i++) {
                TowerPart.Selected.Tower.Tower[i].IsSelectable = i == TowerPart.Selected.Tower.Tower.Count - 1;
            }
        } catch { Debug.Log("Empty Tower");}

        TowerPart.Selected.Tower = this;
        TowerPart.Selected.LastLegalLocation = TowerPart.Selected.GetComponent<RectTransform>().anchoredPosition = new Vector3(GetComponent<RectTransform>().anchoredPosition.x, (-155) - 60 * (4 - LocationAdded), 0);
        TowerPart.Selected = null;
        UpdateTree();
        Check();
    }

    void UpdateTree() {
        try {
            for (int i = 0; i <Tower.Count; i++) {
                Tower[i].IsSelectable = i == Tower.Count-1;
            }
        } catch { Debug.Log("Empty Tower"); }
    }

    void Check() {
        if (IsCorrect) {
            if(Tower.Count == 4) {
                Debug.Log("Correct");
                WinGame.Show();
            }
        }
    }

    void ShowError() {
        Debug.Log("Illegal");
    }
}
