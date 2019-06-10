using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour {


    public Text scoreText;

    public Text highScoreText;

    public Image backgroundImg;
    private bool isShowned = false;
    private float transition = 0.2f;


    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
        

    }
	
	// Update is called once per frame
	void Update () {
        if (!isShowned)
            return;

        transition += Time.deltaTime;
        backgroundImg.color = Color.Lerp(new Color(0, 0, 0, 0), new Color(0, 0, 0, 0.5f), transition);
        highScoreText.text = "" + ((int)PlayerPrefs.GetFloat("HighScore")).ToString();
       
    }

   
    

     public void ToggleEndMenu(float score)
    {

        gameObject.SetActive(true);
        scoreText.text = ((int)score).ToString();
        isShowned = true;
    }
}
