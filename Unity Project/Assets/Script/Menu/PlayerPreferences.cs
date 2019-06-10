using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPreferences : MonoBehaviour
{
    public static string HighScore = "HighScore"; //saving highscore in players (int)
    public static string IsTheMusicOn = "IsTheMusicOn"; //Store the music preference
    public static string IsTheSoundOn = "IsTheSoundOn"; //Store the sound preference


    public static string GameStartedFromMainMenu = "GameStartedFromMainMenu"; // to check if the game is started from main menu ( 0= false, 1=true)
    public static string GameResumedAfterPlayerDied = "GameResumedAfterPlayerDied"; //if the game was resumed after player died ( 0= false, 1=true)



    // 0 = false ; 1 = true;

    public static int GetMusicState()
    {
        return PlayerPrefs.GetInt(PlayerPreferences.IsTheMusicOn);
    }


    // 0 = off ; 1 =on ;

    public static void SetMusicState(int state)
    {
        PlayerPrefs.SetInt(PlayerPreferences.IsTheMusicOn, state);
    }



    // 0 = false ; 1 = true;

    public static int GetSoundState()
    {
        return PlayerPrefs.GetInt(PlayerPreferences.IsTheSoundOn);
    }


    // 0 = off ; 1 =on ;

    public static void SetSoundState(int soundstate)
    {
        PlayerPrefs.SetInt(PlayerPreferences.IsTheSoundOn, soundstate);
    }
}
