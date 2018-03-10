using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins : MonoBehaviour {

    private List<Transform> pins = new List<Transform>();
    private List<Vector3> startPos = new List<Vector3>();
    private int numPinsDown;
    //private bool isChecked = false;
    GameObject bowlingBall;


    void Start() {
        bowlingBall = GameObject.Find("Bowling_Ball");
        foreach (Transform child in transform)
        {
            startPos.Add(child.position);
            pins.Add(child);
        }

    }
    // GetComponent<BowlingBall>().transform.position.
    // Update is called once per frame !isChecked &&
    void Update() {
        if (bowlingBall)
        {
            if (bowlingBall.transform.position.z < 5f)
            {
                Invoke("CheckPins", 5f);//check pins after 5 seconds
                                        //    isChecked = true;
            }
        }
    }

    void CheckPins()
    {
        Debug.Log("Checking");
        foreach (Transform child in pins)// loop through the pins
        {
            if (child.GetComponent<BowlingPin>().isDown == true && child.GetComponent<BowlingPin>().isChecked == false) //check if pin is down
            {
                child.GetComponent<BowlingPin>().isChecked = true;
                child.gameObject.SetActive(false);
                numPinsDown++;
            }
        }
        if (numPinsDown == pins.Count)
        {
            Reset();
        }
    }
    void Reset()
    {
        for (int i = 0; i < pins.Count; i++)
        {
            pins[i].position = startPos[i];
            pins[i].rotation = Quaternion.identity;
            Rigidbody R = pins[i].GetComponent<Rigidbody>();
            R.velocity = Vector3.zero;
            R.angularVelocity = Vector3.zero;
        }
    }
}
