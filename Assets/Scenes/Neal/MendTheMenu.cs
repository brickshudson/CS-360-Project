using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GameLogging;

public class MendTheMenu : MonoBehaviour
{
    #region Public Variables
    public GameWin GameOver;
    public TextMeshProUGUI GoalMenu;
    public Timer timer;

    public TextMeshProUGUI Item1;
    public TextMeshProUGUI Item2;
    public TextMeshProUGUI Item3;
    public TextMeshProUGUI Item4;
    public TextMeshProUGUI Item5;
    public TextMeshProUGUI Item6;
    public TextMeshProUGUI Item7;
    public TextMeshProUGUI Item8;

    public SnapPositions Menu1;
    public SnapPositions Menu2;
    public DropCapture Temp1;
    public DropCapture Temp2;

    public static bool ChangeDetected { get; set; }
    #endregion

    private TextMeshProUGUI[] ItemList;
    private Log Log;

    // Start is called before the first frame update
    // Sets all variables
    void Awake() {
        ItemList = new TextMeshProUGUI[] {Item1,Item2,Item3,Item4,Item5,Item6,Item7,Item8 };
        GoalMenu.text = Food.generateItems(8); 
        string[] Items = GoalMenu.text.Split('\n');
        Items.Shuffle();
        for(int i = 0; i < ItemList.Length; i++) {
            ItemList[i].text = Items[i];
        }
        Menu1.Snap8.IsLast = true;
        Menu2.Snap1.IsLast = true;
        Temp1.IsLast = true;
        Temp2.IsLast = true;

        for(int i = 0; i < ItemList.Length; i++) {
            Menu1.Snaps[i].Snap(ItemList[i].gameObject);
            Menu1.Snaps[i].HasValue = true;
        }

        Log = new Log();
        ChangeDetected = false;
    }

    void UpdateMenus(DropCapture[] menu) {
        for (int i = 0; i < menu.Length; i++) {
            if (!menu[i].HasValue) {
                for (int j = i; j < menu.Length; j++) {
                    try {
                        menu[j].Snap(menu[j + 1].CapturedObject);
                        menu[j].IsLast = false;
                    } catch (System.Exception ex) {
                        Debug.Log($"Skipping item {j} because of {ex.GetType().Name}");
                        menu[j].IsLast = true;
                    }
                }
                break;
            }
        }
    }

    // Update is called once per frame
    // Checks if either menu is correct
    void Update(){
        
        if (!ChangeDetected) { return; } else { ChangeDetected = false; }

        try { Menu1.UpdateValues(); } catch { Debug.Log("Menu 1 Update Error"); }
        try { Menu2.UpdateValues(); } catch { Debug.Log("Menu 2 Update Error"); }


        if (!Menu1.Snap1.HasValue && Menu1.Snap2.HasValue) {
            UpdateMenus(Menu1.Snaps);
        }

        if (!Menu2.Snap1.HasValue && Menu2.Snap2.HasValue) {
            UpdateMenus(Menu2.Snaps);
        }

        Log.TurnsUsed++;
        string checkMenu1 = "", checkMenu2 = "";
        
        //Checks Menu 1
        bool start = true;
        foreach(DropCapture CapturedValue in Menu1.Snaps) {
            if (start) { checkMenu1 += CapturedValue.ValueCaptured; start = false; } else { checkMenu1 += "\n" + CapturedValue.ValueCaptured; }
        }

        //Checks Menu 2
        start = true;
        foreach(DropCapture CapturedValue in Menu2.Snaps) {
            if (start) { checkMenu2 += CapturedValue.ValueCaptured; start = false; } else { checkMenu2 += "\n" + CapturedValue.ValueCaptured; }
        }
        
        //Checks for Win
        if (checkMenu1 == GoalMenu.text || checkMenu2 == GoalMenu.text) { 
            timer.StopTimer();
            Log.TimeTaken = timer is CountDown CountDown ? CountDown.TimeElapsed : timer.Time;
            Log.Win = true;
            Debug.Log("Player win.");
            GameOver.Show();
        }

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
        foreach(string item in FoodItems) {
            if (start) { end += item; start = false; } else { end += "\n" + item; }
        }

        return end;
    }

    //Allows an array to be shuffled.
    public static void Shuffle(this string[] list) {
        int n = list.Length;
        while (n > 1) {
            n--;
            int k = Random.Range(0, n + 1);
            string value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

}