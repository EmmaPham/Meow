using System.Collections;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public static DontDestroyOnLoad instance;
    // Start is called before the first frame update
    void Awake()
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

}
