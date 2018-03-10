﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour {
    public Vector3 startPosition; //Keep track of where bowling ball starts
                                   // Use this for initialization
    void Start () {
        startPosition = transform.position; // Saves position
    }   
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -5f) // if too low
        {
            Debug.Log("falling");
            transform.position = startPosition;
            GetComponent<Rigidbody>().velocity = Vector3.zero; // resets velocity if moving
        }
    }
}
