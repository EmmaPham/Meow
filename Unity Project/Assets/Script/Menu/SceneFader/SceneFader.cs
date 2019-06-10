using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public static SceneFader instance;

    [SerializeField]
    private GameObject faderPanel;

    [SerializeField]
    private Animator FaderAnim;


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


    public void LoadLevel(string level)
    {
        StartCoroutine(FadeInOut(level));
    }

    IEnumerator FadeInOut(string level)
    {
        faderPanel.SetActive(true);
        FaderAnim.Play("FadeIn");

        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(level);
        FaderAnim.Play("FadeOut");

        yield return new WaitForSeconds(0.5f);
        faderPanel.SetActive(false);

    }
}
