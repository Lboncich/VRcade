using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour {
    public Pins currentPins = new Pins();
    private int pinsHit { get; set; }
    private bool isStrike;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public int rollBall()
    {
        pinsHit = currentPins.numPinsDown;
        if (pinsHit == 10)
            isStrike = true;
        return pinsHit;
    }
    public bool getIsStrike()
    {
        return isStrike; 
    }
}
