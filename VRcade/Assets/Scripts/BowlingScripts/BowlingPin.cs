using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPin : MonoBehaviour
{


    //
    public AudioSource hitSource;
    //
    public Transform pin;
    public float threshhold = .6f;
    public int point = 1;
    public bool isDown = false;
    public bool isChecked = false;
    //public Score score
    // Use this for initialization


    void Start()
    {
        hitSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (pin.up.y < threshhold)
        {
            //add score
            Debug.Log("Pin is Down");

            isDown = true;
        }
    }

    void OnCollisionEnter (Collision collision)
    {
       
                    hitSource.Play();
            Debug.Log("hello");
        
    }
     
    }

