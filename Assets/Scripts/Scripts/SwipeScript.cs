using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeScript : MonoBehaviour
{
    Vector2 startTouchPos, endTouchPos;

    bool canSwipe;

    public bool CanSwipe { get => canSwipe; set => canSwipe = value; }

    private void Start()
    {
        CanSwipe = true;
    }
    private void Update()
    {
        if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPos = Input.GetTouch(0).position;
            if(startTouchPos.x < endTouchPos.x && CanSwipe)
            {
                GetComponent<SpinManager>().moveSpin(-1);
            }
            else if(startTouchPos.x > endTouchPos.x && CanSwipe)
            {

                GetComponent<SpinManager>().moveSpin(1);
            }
        }
    }
}
