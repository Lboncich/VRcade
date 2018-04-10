using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour {
    
    private Roll currentRoll;        //between 0 and 1
    private int frameNumber { get; set; }        //between 0 and 11
    private int frameScore { get; set; }
    private bool isSpare;
    private bool isStrike;
                                    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public int getFrameNumber()
    {
        return frameNumber;
    }
    public void setFrameNumber(int num)
    {
        frameNumber = num;
    }
    public int getFrameScore()
    {
        return frameScore;
    }
    public void setFrameScore(int num)
    {
        frameScore = num;
    }
    public void incrementFrameScore(int num)
    {
        frameScore += num;
    }
    public Roll getCurrentRoll()
    {
        return currentRoll;
    }
    private void determineSpare()
    {

    }
    private void determineStrike()
    {

    }
}
