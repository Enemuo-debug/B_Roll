using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DirectionSnap : MonoBehaviour
{
    // Reference Ball Control Script
    private BallControl ballControl;
    // Start is called before the first frame update
    void Start()
    {
        ballControl = GameObject.Find("BaseBall").GetComponent<BallControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("hhh"))
        {
            Debug.Log("collided");
        }
    }
}
