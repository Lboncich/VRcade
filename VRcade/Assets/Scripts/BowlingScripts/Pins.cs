using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pins : MonoBehaviour {

    private List<Transform> pins = new List<Transform>();
    private List<Vector3> startPos = new List<Vector3>();

    
    public int NumPinsDown
    {
        get;
        private set;
    }
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

        //CheckPins();
        ////if (bowlingBall.transform.position.z < 5f)
        ////{
        ////    Invoke("CheckPins", 5f);//check pins after 5 seconds
        ////    CheckPins();                    //    isChecked = true;
        ////}
     

    }

    public void CheckPins()
    {
        foreach (Transform child in pins)// loop through the pins
        {
            if (child.GetComponent<BowlingPin>().isDown == true && child.GetComponent<BowlingPin>().isChecked == false) //check if pin is down
            {
                child.GetComponent<BowlingPin>().isChecked = true;
                //StartCoroutine(setPinsInactive(child));
                NumPinsDown++;
                //textBox.text = "Score:" + numPinsDown;
            }
        }
        
    }

    public IEnumerator setPinsInactive(Transform child)
    {
        
        yield return new WaitForSeconds(1);
        child.gameObject.SetActive(false);
        //if (NumPinsDown == pins.Count)
        //{
        //    Reset();
        //}
    }

    public IEnumerator Reset()
    {

        //foreach (Transform child in pins)
        //{
        //    child.gameObject.SetActive(true);

        //    child.rotation = Quaternion.identity;
        //}
        Debug.Log("Being reset");
        yield return new WaitForSeconds(3);
        for (int i = 0; i < pins.Count; i++)
        {
         
            pins[i].position = startPos[i];
            pins[i].rotation = Quaternion.identity;
            pins[i].GetComponent<BowlingPin>().isChecked = false;
            pins[i].gameObject.SetActive(true);
            pins[i].GetComponent<BowlingPin>().isDown = false;


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
        NumPinsDown = 0;
    }
}
