//Written by The-Architect01
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QueueHost : MonoBehaviour
{
    public List<QueueItem> Queue = new List<QueueItem>();
    public static int TurnsTaken = 0;
    public GameWin WinGame;
    public TextMeshProUGUI Correct;

    private void Start() {
        Correct.text = Food.generateItems(8);
        string[] Foods = Correct.text.Split('\n');
        Foods.Shuffle();
        try {
            int i = 0;
            foreach(QueueItem Item in Queue) {
                Item.GetComponent<TextMeshProUGUI>().text = Foods[i];
                i++;
            }
        } catch { }
    }

    public void OnClick() {
        if (QueueItem.Selected == null) { return; }
        if (Queue.Contains(QueueItem.Selected)) { return; }
        TurnsTaken++;
        Queue.Add(QueueItem.Selected);
        int LocationAdded = 0;

        foreach (QueueItem TP in Queue) {
            LocationAdded++;
        }

        if (QueueItem.Selected.Host != null) {
            QueueItem.Selected.Host.Queue.Remove(QueueItem.Selected);
            QueueItem.Selected.Host.UpdateTree();
        }

        QueueItem.Selected.Host = this;

        try {
            for (int i = 0; i < QueueItem.Selected.Host.Queue.Count; i++) {
                QueueItem.Selected.Host.Queue[i].IsSelectable = i == 0;
            }
        } catch { Debug.Log("Empty Tower"); }

        QueueItem.Selected.GetComponent<RectTransform>().anchoredPosition = new Vector3(
            GetComponent<RectTransform>().anchoredPosition.x + 25, 
            (10) - 60 * (Queue.Count-1), 
            0
        );
        QueueItem.Selected.IsSelectable = (Queue.IndexOf(QueueItem.Selected) == 0);
        
        QueueItem.Selected = null;
        Check();
    }

    public void UpdateTree() {
        try {
            for (int i = 0; i < Queue.Count; i++) {
                Queue[i].IsSelectable = i == 0;
                Queue[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(
                    GetComponent<RectTransform>().anchoredPosition.x + 25,
                    (10) - 60 * i,
                    0
                );
            }
        } catch { Debug.Log("Empty Tower"); }
    }


    void Check() {
        string Answer = "";
        foreach(QueueItem item in Queue) {
            Answer += item.GetComponent<TextMeshProUGUI>().text + "\n";
        }
        if(Answer.Replace("\n",string.Empty) == Correct.text.Replace("\n",string.Empty)) { WinGame.Show(); }
    }

}

public static class Food {

    static string[] FoodItems { get; } = {
        "Sandwich",
        "Steak",
        "Pudding",
        "Pizza",
        "Pie",
        "Fish",
        "Hamburger",
        "Ice Cream"
    };

    //Makes the food readable
    public static string generateItems(int items) {
        FoodItems.Shuffle();
        string end = "";
        bool start = true;
        foreach (string item in FoodItems) {
            if (start) { end += item; start = false; } else { end += "\n" + item; }
        }

        return end;
    }

    //Allows an array to be shuffled.
    public static void Shuffle<T>(this T[] list) {
        int n = list.Length;
        while (n > 1) {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

}