using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager instance;

    [SerializeField]
    private AudioSource soundFX;

    [SerializeField]
    private AudioClip[] audioclips;
        
        
        //landClip, deathClip, breakableClip, strikeClip;



    void Awake()
    {
        MakeSingleton();
        


    }

    

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }


    public void LandSound()
    {
        

        if (PlayerPreferences.GetSoundState() == 0)
        {
            
            SoundFX(false);
            

        }else
        {
            soundFX.clip = audioclips[0];
            SoundFX(true);
        }
        




    }

   public void DeathSound()
    {
       
      
        if(PlayerPreferences.GetSoundState() == 0)
        {
           
            SoundFX(false);


        }else
        {
            soundFX.clip = audioclips[1];
            SoundFX(true);
        }

    }

    public void BreakSound()
    {
        
            
        if(PlayerPreferences.GetSoundState() == 0)
        {

            SoundFX(false);


        }else
        {
            soundFX.clip = audioclips[2];
            SoundFX(true);
        }

    }

    public void Poke()
    { 
           


        if (PlayerPreferences.GetSoundState() == 0)
        {

            SoundFX(false);
            

        }
        else
        {
            soundFX.clip = audioclips[3];
            SoundFX(true);


        }

    }


    public void Click_SFX()
    {

        if (PlayerPreferences.GetSoundState() == 0)
        {

            SoundFX(false);


        }
        else
        {
            soundFX.clip = audioclips[4];
            SoundFX(true);


        }
    }



    public void Play_SFX()
    {

        if (PlayerPreferences.GetSoundState() == 0)
        {

            SoundFX(false);


        }
        else
        {
            soundFX.clip = audioclips[5];
            SoundFX(true);


        }
    }


    public void SoundFX(bool fx)
    {
        
            if (fx)
            {
                if (!soundFX.isPlaying)
                {



                
                soundFX.Play();
                    
                }
            }
            else
            {
                if (soundFX.isPlaying)
                {
                soundFX.clip = null;
                
                }

            }

        
    }




    public void turnoffSound()
    {
        soundFX.clip = null;
    }
    


}
