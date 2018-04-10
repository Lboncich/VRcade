using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pins : MonoBehaviour {

    private List<Transform> pins = new List<Transform>();
    private List<Vector3> startPos = new List<Vector3>();
    public int numPinsDown;
    public Text textBox;
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

        Invoke("CheckPins", 5f);
        ////if (bowlingBall.transform.position.z < 5f)
        ////{
        ////    Invoke("CheckPins", 5f);//check pins after 5 seconds
        ////    CheckPins();                    //    isChecked = true;
        ////}
     

    }

    void CheckPins()
    {
        //Debug.Log("Checking");
        foreach (Transform child in pins)// loop through the pins
        {
            if (child.GetComponent<BowlingPin>().isDown == true && child.GetComponent<BowlingPin>().isChecked == false) //check if pin is down
            {
                child.GetComponent<BowlingPin>().isChecked = true;
                StartCoroutine(setPinsActive(child));
                numPinsDown++;
                textBox.text = "Score:" + numPinsDown;
            }
        }
       
    }
    IEnumerator setPinsActive(Transform child)
    {
        
        yield return new WaitForSeconds(3);
        child.gameObject.SetActive(false);
        if (numPinsDown == pins.Count)
        {
            Reset();
        }
    }
    void Reset()
    {

        //foreach (Transform child in pins)
        //{
        //    child.gameObject.SetActive(true);

        //    child.rotation = Quaternion.identity;
        //}
        for (int i = 0; i < pins.Count; i++)
        {
            pins[i].position = startPos[i];
            pins[i].rotation = Quaternion.identity;
            pins[i].gameObject.SetActive(true);


            //for (int i = 0; i < pins.Count; i++)
            //{
            //    pins[i].position = startPos[i];
            //    pins[i].rotation = Quaternion.identity;
            //    Rigidbody R = pins[i].GetComponent<Rigidbody>();
            //    R.gameObject.SetActive(true);
            //  //  R.velocity = Vector3.zero;
            //  //  R.angularVelocity = Vector3.zero;
            //}
        }
    }
    }
