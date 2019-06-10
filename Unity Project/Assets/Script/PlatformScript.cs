using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformScript : MonoBehaviour {
    private float move_speed = 1.4f;
    public float bound_Y = 6; // set limit for platform

    public GameObject[] boomfx;
    public bool is_StandardFlatform, is_Strike, is_Exploision;
    private Animator anim;

    public string boomFXTag = "BoomFX";

    void Awake()
    {
        if (is_Exploision)
        {
            anim = GetComponent<Animator>();
        }

        if (boomFXTag != "")
        {
            boomfx = GameObject.FindGameObjectsWithTag(boomFXTag);
        }
    }

    

    // Update is called once per frame
    void Update () {
        Move();
	}
    
    void Move()
    {
        Vector2 temp = transform.position; // moving to the position
       
        temp.y += move_speed * Time.deltaTime; //moving in the y axis with the move_speed and time
        transform.position = temp; 

        if (temp.y > bound_Y)
        {
            gameObject.SetActive(false);
        }

    } // move


   




    void ExploisionDeactivated()
    {
        Invoke("DeactivateGameObject",0.3f);
    }

    void DeactivateGameObject()
    {
        //SoundManager.instance.exploisionsound();
        gameObject.SetActive(false);
        //BoomFX();
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            if (is_Strike)
            {

                
                target.transform.position = new Vector2(1000f, 1000f); 
                FindObjectOfType<PlayerBounce>().Death();
                SoundManager.instance.Poke();


            }
        } 
    }



    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Player")
        {
            if (is_Exploision)
            {
                //SoundManager
                anim.Play("Exploision");
                Invoke("BoomFX", 0.5f);
                SoundManager.instance.BreakSound();

            }

            if (is_StandardFlatform)
            {
                SoundManager.instance.LandSound();
                FindObjectOfType<Player>().LandFX();

            }

        }
    }

    public void BoomFX()
    {
        int i = 0;
        foreach (Transform child in gameObject.transform)
        {
            if (boomfx[i])
            {
                boomfx[i].transform.position = new Vector3(child.position.x, child.position.y, -2f);
                ParticlePlayer particleboom = boomfx[i].GetComponent<ParticlePlayer>();
                if (particleboom)
                {
                    particleboom.Play();
                }

            }
            i++;
        }
    }

}
