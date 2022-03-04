using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using GameLogging;

[Serializable]
public class PlayerStats {

    public Dictionary<string, Dictionary<string, Stat>> Stats { get; private set; }

    public PlayerStats() {
        try {
            Stats = PlayerIO.LoadData().Stats;
            Debug.Log("Player history detected");
        } catch (NoSaveFileException) {
            MiniGameLister MGL = Zombie.MiniGameList;
            Stats = new Dictionary<string, Dictionary<string, Stat>>();
            foreach(string Category in MGL.GetListofCategories()) {
                Dictionary<string, Stat> DataStruct = new Dictionary<string, Stat>();
                foreach(string MiniGame in MGL.GetSceneNamesFromCategory(Category)) {
                    DataStruct.Add(MiniGame, new Stat());
                }
                Stats.Add(Category, DataStruct);
            }        
            PlayerIO.SaveData(this);
            Debug.Log("New Player Record Created");
        }
    }

}

[Serializable]
public class Stat {

    public float BestTime { get; set; } = 0;
    public long BestScore { get; set; } = 0;
    public long GamesPlayed { get; set; } = 0;
    public long GamesWon { get; set; } = 0;
    public long GamesLost { get; set; } = 0;
    public long TimesPracticed { get; set; } = 0;
    public long TimesPlayed { get; set; } = 0;

    /// <summary>A Log of Games Played</summary>
    public GameLogs GameLog { get; } = new GameLogs();

    public Stat() {
        GameLog.ListChanged += (sender, e) => {
            if(e.TimeTaken < BestTime) { BestTime = e.TimeTaken; }
            if(e.Score > BestScore) { BestScore = e.Score; }
            if (e.Win && !e.IsPractice) { GamesWon++; } else { GamesLost++; }
            if (e.IsPractice) { TimesPracticed++; } else { TimesPlayed++; }
            GamesPlayed++;
        };
    }
    
}

namespace GameLogging {

    [Serializable]
    public class GameLogs: List<Log> {

        public event EventHandler<Log> ListChanged;

        public new void Add(Log item) {
            if(ListChanged != null && item != null) { ListChanged.Invoke(this, item); }
            base.Add(item);
        }

    }

    [Serializable]
    public class Log {
        public long TurnsUsed { get; set; } = -1;
        public long ErrorsMade { get; set; } = -1;
        public long Score { get; set; } = -1;
        public float TimeTaken { get; set; } = -1;
        public bool IsTeamGame { get; set; } = false;
        public bool IsPractice { get; set; } = false;
        public bool Win { get; set; } = false;
    }
}

public static class PlayerIO {

    private static readonly string Path = Application.persistentDataPath + "/History.survive";
    private static readonly BinaryFormatter Serializer = new BinaryFormatter();

    public static void SaveData(PlayerStats player) {
        using FileStream file = new FileStream(Path, FileMode.Create);
        Serializer.Serialize(file, player);
    }

    public static PlayerStats LoadData() { 
        if (File.Exists(Path)) {
            using FileStream file = new FileStream(Path, FileMode.Open);
            return Serializer.Deserialize(file) as PlayerStats;
        } else {
            Debug.Log("File was not found " + Path);
            throw new NoSaveFileException();
        }
    }
}
class NoSaveFileException : Exception { }