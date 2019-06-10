using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour {


    public Swipe swipeControl;
    public Transform Player;
    private Vector3 desiredPosition;
    public float movespeed = 10f;
    private float smoothMovement = 15f;

    private void Start()
    {
        desiredPosition = Player.position;
    }

    // Update is called once per frame
    void Update () {
		if (swipeControl.SwipeLeft)
        { 
            desiredPosition += Vector3.left * movespeed;
        }

        if (swipeControl.SwipeRight)
        {
            desiredPosition += Vector3.right * movespeed;
        }

        Player.transform.position = Vector3.MoveTowards(Player.transform.position, desiredPosition, Time.fixedDeltaTime);
       


    }
}
