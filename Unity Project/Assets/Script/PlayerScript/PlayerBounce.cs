using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounce : MonoBehaviour {
    public float min_X = -1.5f, max_X= 1.5f, min_Y= -5.5f;

    private bool outOfBound;
    private bool isDeath = false;

	// Update is called once per frame
	void Update () {
        CheckBounce();
        if (isDeath)
            return;
	}

    void CheckBounce()
    {
        Vector2 temp = transform.position;
        if (temp.x > max_X)
            temp.x = max_X; // set player not go through max X
        if (temp.x < min_X)
            temp.x = min_X;

        transform.position = temp; // reset value back to current position

        if (temp.y <= min_Y)
        {
            if (!outOfBound)
            {
                outOfBound = true;
                SoundManager.instance.DeathSound();
                
                Death();

               
            }
        }
    }


     void OnTriggerEnter2D(Collider2D target)
    {
        if ( target.tag == "TopSpike")
        {
            transform.position = new Vector2(1000f, 1000f);
            SoundManager.instance.DeathSound();
            Death();
           
        }
    }


    public void Death()
    {
        isDeath = true;
        
        GetComponent<Score>().onDeath();
    }

}
