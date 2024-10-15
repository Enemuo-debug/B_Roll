using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BallControl : MonoBehaviour
{
    //Get the RigidBody for the ball object
    private Rigidbody ballRb;
    // Get our boolean isTravelling Variable
    public bool isTravelling = false;
    // Travel Direction
    private Vector3 travelDirection;
    // Initial MouseDown Position
    private Vector2 initialSwipe;
    private Vector2 finalSwipe;
    // Get direction Game Object
    private GameObject nav;
    // Decliare speed variable
    private int speed = 3;
    // Offesets
    private Vector3 XOffset = new Vector3 (0.45f, 0, 0);
    private Vector3 YOffset = new Vector3(0, 0, 0.45f);
    // Start is called before the first frame update
    void Start()
    {
        nav = GameObject.Find("direction");
        nav.transform.position = transform.position;
        ballRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSwipeAxis(initialSwipe, finalSwipe);
        if (!isTravelling) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                initialSwipe = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                finalSwipe = Input.mousePosition;
                isTravelling = true;
            }
        }
        ballRb.velocity = travelDirection*speed;
    }

    void GetSwipeAxis (Vector2 init, Vector2 final) 
    {
        double dy = final.y - init.y;
        double dx = final.x - init.x;
        

        if (Math.Abs(dy) > Math.Abs(dx)) // We are in the y axis 
        {
            if (dy < 0) {
                travelDirection = Vector3.back;
                nav.transform.position = transform.position - YOffset;
            } else {
                travelDirection = Vector3.forward;
                nav.transform.position = transform.position + YOffset;
            }
        } else if (Math.Abs(dx) > Math.Abs(dy)) { // Were in the X axis
            if (dx < 0) {
                travelDirection = Vector3.left;
                nav.transform.position = transform.position - XOffset;
            } else {
                travelDirection = Vector3.right;
                nav.transform.position = transform.position + XOffset;
            }
            
        } else { // Indeterminate Swipe
            //Debug.Log("Indeterminate Swipe");
        }
    }
}
