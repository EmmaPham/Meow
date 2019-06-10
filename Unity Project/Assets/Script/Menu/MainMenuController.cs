using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{
    public static MainMenuController instance;


    [SerializeField]
        private Button MusicBtn;
    [SerializeField]
    private Sprite[] musicIcon;



    [SerializeField]
    private Button SoundBtn;
    [SerializeField]
    private Sprite[] soundIcon;


    


    void Start()
    {
        IsTheGamePlayedForTheFirstTime();
        CheckMusic();
        CheckSound();
        SoundManager.instance.turnoffSound();
    }
     void Update()
    {
        CheckForTouch();
    }

    void CheckForTouch()
    {
        //is there any touch 
        if (Input.touchCount > 0)
        {
            // if yes get the first touch
            Touch t = Input.touches[0];

            if (t.phase == TouchPhase.Began)
            {
                Vector3 worldPoint = Camera.main.ScreenToWorldPoint(t.position);
                Vector2 touchPos = new Vector2(worldPoint.x, worldPoint.y);

                Collider2D hit = Physics2D.OverlapPoint(touchPos);


            }

        }

    }


    public void PlayBtn()
    {
        PlayerPrefs.SetInt(PlayerPreferences.GameStartedFromMainMenu, 1);
        //SceneManager.LoadScene("GamePlay");
        SceneFader.instance.LoadLevel("GamePlay");

        

       if (PlayerPreferences.GetSoundState() == 1)
        {
            
            SoundManager.instance.SoundFX(true);
            SoundManager.instance.Play_SFX();

        }
       

    }


    public void MusicButton()
    {
        if (PlayerPreferences.GetMusicState() == 0)
        {
            PlayerPreferences.SetMusicState(1);
            MusicController.instance.PlayMusic(true);
            SoundManager.instance.Click_SFX();
            MusicBtn.image.sprite = musicIcon[0];

        }
        else if (PlayerPreferences.GetMusicState() == 1)
        {
            PlayerPreferences.SetMusicState(0);
            MusicController.instance.PlayMusic(false);
            
            MusicBtn.image.sprite = musicIcon[1];
        }
    }



    public void SoundButton()
    {
        SoundManager.instance.turnoffSound();
        if (PlayerPreferences.GetSoundState() == 0)
        {
            PlayerPreferences.SetSoundState(1);
            SoundManager.instance.SoundFX(true);
            SoundManager.instance.Click_SFX();
            SoundBtn.image.sprite = soundIcon[0];

        }
        else if (PlayerPreferences.GetSoundState() == 1)
        {
            PlayerPreferences.SetSoundState(0);
            SoundManager.instance.SoundFX(false);
            SoundManager.instance.turnoffSound();
            SoundBtn.image.sprite = soundIcon[1];
          
        }
    }


    


    void IsTheGamePlayedForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey("GamePlayed"))

        {
            //set the default highscore 
            PlayerPrefs.SetInt(PlayerPreferences.HighScore, 0);
            //the music and sound is on by default
            PlayerPrefs.SetInt(PlayerPreferences.IsTheMusicOn, 1);
            PlayerPrefs.SetInt(PlayerPreferences.IsTheSoundOn, 1);
            
            //Set the GamePlay value to 1, next time when check if this key exist it will be true
            // which means that the game has opened and no need to set up default values anymore
            PlayerPrefs.SetInt("GamePlayed", 1);
        }
    }

    void CheckMusic()
    {
        if (PlayerPreferences.GetMusicState() == 1) // if the music is on, play music and set the icon music on
        {
            MusicController.instance.PlayMusic(true);
            MusicBtn.image.sprite = musicIcon[0];
        } else
        {
            MusicController.instance.PlayMusic(false); // if the music is off , stop play music and set the icon music off
            MusicBtn.image.sprite = musicIcon[1];

        }

    }

    void CheckSound()
    {
        if (PlayerPreferences.GetSoundState() == 1) // if the sound is on, play sound and set the icon sound on
        {
            SoundManager.instance.SoundFX(true);
            SoundBtn.image.sprite = soundIcon[0];
        }
        else
        {
            SoundManager.instance.SoundFX(false); // if the sound is off , stop play sound and set the icon sound off
            SoundBtn.image.sprite = soundIcon[1];

        }
    }

    
   

}
