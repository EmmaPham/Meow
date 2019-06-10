using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

     void Awake()
    {
       if (instance == null)
        {
            instance = this;
        }
     }


    public void Restart()
    {

        
        SceneFader.instance.LoadLevel(SceneManager.GetActiveScene().name);

        if (PlayerPreferences.GetSoundState() == 1)
        {

            SoundManager.instance.SoundFX(true);
            SoundManager.instance.Click_SFX();

        }

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {

        // SceneManager.LoadScene("Menu");
        SceneFader.instance.LoadLevel("Menu");

        if (PlayerPreferences.GetSoundState() == 1)
        {

            SoundManager.instance.SoundFX(true);
            SoundManager.instance.Click_SFX();

        }

    }

    

}
