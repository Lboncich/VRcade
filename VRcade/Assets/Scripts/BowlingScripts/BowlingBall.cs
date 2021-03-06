﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour {
    private Vector3 startPosition; //Keep track of where bowling ball starts
   public Rigidbody rigidBody;
    // Use this for initialization
    public AudioSource ballSoundSource;
    public AudioSource initalHit;
    
    public Vector3 vel;
    public float speed;
    public bool isDropped = false;

    void Start() {
        //startPosition = transform.position; // Saves position
        rigidBody = GetComponent<Rigidbody>();
        //ballSoundSource = GetComponent<AudioSource>();
        //initalHit = GetComponent<AudioSource>();
       // ballSoundSource = aSources[0];
        var aSources = GetComponents<AudioSource>();
        ballSoundSource = aSources[0];
        initalHit = aSources[1];
        startPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
  
    }

    // Update is called once per frame
    void Update() {
        if (transform.position.y < -5f) // if too low
        {
            Debug.Log("falling");
            transform.position = startPosition;
            GetComponent<Rigidbody>().velocity = Vector3.zero; // resets velocity if moving
        }
      vel = rigidBody.velocity;      //to get a Vector3 representation of the velocity
       speed = vel.magnitude;             // to get magnitude

    }

    public void Reset()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        transform.position = startPosition;
        isDropped = false;
    }

    
    void OnCollisionStay(Collision collision)
    {
        if(!isDropped && collision.gameObject.tag == "Lane")
        {
            initalHit.Play();
            initalHit.Play();
            initalHit.Play();
            initalHit.Play();
            isDropped = true;
            Debug.Log("testing");

        }
        if (ballSoundSource.isPlaying == false && speed >= 0.1f && collision.gameObject.tag == "Our Lane")
         {
             ballSoundSource.Play();

         }
         else if (ballSoundSource.isPlaying == true && speed < 0.1f && collision.gameObject.tag == "Our Lanes")
         {
             ballSoundSource.Pause();
         }
         
        if (speed >= 1f && ballSoundSource.isPlaying == false)
        {
           ballSoundSource.Play();
        }
        else if (speed < 0.5f && ballSoundSource.isPlaying == true )
        {
            ballSoundSource.Pause();
        }
    }

  void OnCollisionExit(Collision collision)
    {
        if (ballSoundSource.isPlaying == true && collision.gameObject.tag == "Lane")
        {
            ballSoundSource.Pause();
        }


    }
}
