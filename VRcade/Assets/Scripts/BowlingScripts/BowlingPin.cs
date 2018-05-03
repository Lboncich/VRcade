using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPin : MonoBehaviour
{


    //
    public AudioSource randomSound;
    public AudioClip[] audioSources;
    public Transform pin;
    //threshold is how far the pin must fall in order to count as being downed
    public float threshhold = .7f;
    public int point = 1;
    public bool isDown = false;
    public bool isChecked = false;
    //public Score score
    // Use this for initialization


    void Start()
    {
        randomSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (pin.up.y < threshhold)
        {
            //add score
            //Debug.Log("Pin is Down");

            isDown = true;
        }
    }

    void OnCollisionEnter (Collision collision)
    {
       // randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
        randomSound.Play();

    }
     
}

