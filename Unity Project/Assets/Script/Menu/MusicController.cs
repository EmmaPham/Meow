using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;
    [SerializeField]
    private AudioSource bgmusic;

    // Start is called before the first frame update
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


    public void PlayMusic (bool play)
    {
        if (play)
        {
            if (!bgmusic.isPlaying)
            {
                bgmusic.Play();
            }
        }
        else
        { if (bgmusic.isPlaying)
            {
                bgmusic.Stop();
            }

        }
        
    }

}
