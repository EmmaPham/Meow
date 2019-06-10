using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody2D mybody;

    public float moveSpeed = 2f;

    public Joystick joystick;

    float horizontalMove = 0f;

    public GameObject[] m_glowSquareFX;
    public string glowSquareTag = "LandFX";

    private 


    // Use this for initialization
    void Start () {
        mybody = GetComponent<Rigidbody2D>();
       

        if (glowSquareTag != "")
        {
            m_glowSquareFX = GameObject.FindGameObjectsWithTag(glowSquareTag);
        }

      

    }
   

    // FixedUpdate for the object has a rigidbody
    void FixedUpdate () {
        Move();
	}


    




    void Move()
    {

       if(joystick.Horizontal >= .6f)
        {
            mybody.velocity = new Vector2(moveSpeed, mybody.velocity.y);
        }
       else if (joystick.Horizontal <= -.6f)
        {
            mybody.velocity = new Vector2(-moveSpeed, mybody.velocity.y);
        }
        else
        {
            horizontalMove = 0f;
        }


       

        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            mybody.velocity = new Vector2(moveSpeed, mybody.velocity.y);
         
        }

        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            mybody.velocity = new Vector2(-moveSpeed, mybody.velocity.y);

        }


      


       





    }

    public void LandFX()
    {
        int i = 0;
        foreach (Transform child in gameObject.transform)
        {
            if (m_glowSquareFX[i])
            {
                m_glowSquareFX[i].transform.position = new Vector3(child.position.x, child.position.y, -2f);
                ParticlePlayer particlePlayer = m_glowSquareFX[i].GetComponent<ParticlePlayer>();
                if (particlePlayer)
                {
                    particlePlayer.Play();
                }

            }
            i++;
        }
    }
   

}
