//Written by The-Architect01
using System;
using UnityEngine;
using Discord;

public class DiscordController{

    private string _screenName;
    public string ScreenName {
        get { return _screenName; }
        set { _screenName = value; UpdateDiscord(value); }
    }

    static Discord.Discord discord = null;// = new Discord.Discord(939698372485476403, (ulong)CreateFlags.NoRequireDiscord);
    static readonly string GameName = "CS 360 Game";

    private void UpdateDiscord(string value) {
        // Update Discord status (if Discord was opened recently, initialize it)
        if(discord != null || InitializeDiscord())
        {
            Activity Game = new Activity() {
                ApplicationId = 939698372485476403,
                Name = GameName,
                State = value,
                Details = Zombie.IsSolo ? "Solo Mode" : "Group Mode",
                Timestamps = { Start = Unix(DateTime.UtcNow), },
                Assets = {
                    LargeImage = "logo",
                    LargeText = GameName,
                }
            };
            discord.GetActivityManager().UpdateActivity(Game, (result) => {
                if (result == Result.Ok) {
                    Debug.Log("Discord Activity Updated!");
                } else {
                    Debug.Log("Discord Activity Update Failed: " + result);
                }
            });
        }
    }

    private bool InitializeDiscord(){
        try
        {
            // If discord integration has not been initialized for the game, try to initialize it
            discord = new Discord.Discord(939698372485476403, (ulong)CreateFlags.NoRequireDiscord);

            Debug.Log("Discord Loaded Successfully");

            return true;
        }
        catch(ResultException /*e*/) // To receive information about the exception, uncomment this variable and the following Debug.log()
        {
            // Debug.Log(e.ToString());
            Debug.Log("Discord load failed. User probably has not opened Discord.");
        }

        return false;
    }

    // Constructor
    public DiscordController(){
        if(InitializeDiscord()) // If discord initializes properly
            ScreenName = "Main Menu"; // Update the discord status
    }


    public void OnApplicationQuit() {
        if (discord != null)
        {
            // Use discord's built in cleanup function
            discord.Dispose();

            // Set discord to null to prevent update on the last frame
            discord = null;
            
            Debug.Log("Discord Controller Closed");
        }
    }

    public void Update() {
        if(discord != null){
            try{
                discord.RunCallbacks();
            }catch(ResultException /*e*/) { // To receive information about the exception, uncomment this variable and the following Debug.log()
                //Debug.Log(e.ToString());
                Debug.Log("Discord Update Failed. Gracefully closing the Discord Controller.\nUser may have closed Discord during the game.");
                // Close the controller and prevent updates
                discord.Dispose();
                discord = null;
            }
        }
    }

    public static long Unix(DateTime time) {
        DateTime UnixEpoch = new DateTime(1970, 1, 1);
        return (long) time.Subtract(UnixEpoch).TotalSeconds;
    }

}
