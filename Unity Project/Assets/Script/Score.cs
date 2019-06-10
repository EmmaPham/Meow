using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {

    private float score = 0.0f;
    public Text scoreText;

    public DeathMenu DeathMenu;
    public GameObject Spawpoint;
    public GameObject StandardObject;
    public GameObject score_text;
    public GameObject joystick;

    private bool isDeath = false;

   


	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {

        if (isDeath)
            return;

        score += Time.deltaTime;
        scoreText.text = ((int)score).ToString();
        
    }

   

    public void onDeath()
    {
        isDeath = true;


        if (PlayerPrefs.GetFloat("HighScore") <= score)
        PlayerPrefs.SetFloat("HighScore", score); 
        

        DeathMenu.ToggleEndMenu(score);
        //Time.timeScale = 0;
        Spawpoint.SetActive(false);
        StandardObject.SetActive(false);
        score_text.SetActive(false);
        joystick.SetActive(false);


    }

}
