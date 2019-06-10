using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;

     AudioSource soundFX;

    void Awake()
    {
        MakeSingleton();
        soundFX = GetComponent<AudioSource>();


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

    public void SoundFX(bool soundfx)
    {
        if (soundfx)
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
                soundFX.Stop();
            }

        }
    }

}
