using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour {
    private Roll[] rolls;
    private Roll currentRoll;        //between 0 and 1
    private int frameNumber { get; set; }   //between 0 and 11
    private int frameScore { get; set; }    //current Frame's score, not total score    
    private bool isSpare;                   //not sure if i should do previous frames spare or strike or current frame
    private bool isStrike;                  //ditto
    public Frame(int num)
    {
        currentRoll = new Roll();
        rolls[0] = currentRoll;
        rolls[1] = null;        //null because this is the beginning of a frame
        frameNumber = num;
        frameScore = 0;
    }
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
    public bool determineSpare()
    {
        if (rolls[1] != null && frameScore == 10) //meaning a 2nd roll happened this frame
            isSpare = true;
        else
            isSpare = false;
        return isSpare;
    }
    public bool getStrike()
    {
        isStrike = currentRoll.getIsStrike();
        return isStrike;
    }
}
