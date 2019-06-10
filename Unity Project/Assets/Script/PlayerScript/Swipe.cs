using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool tap, swipeLeft, swipeRight;
    private bool isDraging;

    private Vector2 startTouch, swipeDelta;

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool Tap { get { return tap; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }


    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }

    private void FixedUpdate()
    {
        tap = swipeLeft = swipeRight = false;

        #region Mobile Inputs
        if (Input.touches.Length >0)
        { if (Input.touches[0].phase == TouchPhase.Began)
            { tap = true;
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
        else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                Reset();
                isDraging = false;
            }
                    
                    
        }
        #endregion

        //Calculate the distance

        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }

        }

        // deadzone
        if (swipeDelta.magnitude > 1)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf. Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            Reset();
        }


    }



}