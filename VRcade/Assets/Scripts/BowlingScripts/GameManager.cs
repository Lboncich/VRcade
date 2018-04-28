using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    public GameObject startingLine;

    public BowlingBall ball;

    //public GameObject legalRegion;

    private bool isValidRoll;

    private Bowling bowlingGame;

    public bool IsValidRoll
    {
        get; set;
    }

    public bool IsLegalRegion
    {
        get;set;
    }
    void Start()
    {
        bowlingGame = new Bowling();
        IsLegalRegion = true;
    }
    // Update is called once per frame
    void Update () {

        if (!IsLegalRegion)
        {
            Resetball();
            
        }
        //GameObject bowlingball = GameObject.Find("Bowling_Ball");
        //if (bowlingball.transform.position.z < startingLine.transform.position.z)//bowling ball is in legal boundary
        //{
        //    IsValidRoll = true;
        //}
        //else
        //    IsValidRoll = false;

        
    }

    public void Resetball()
    {
        
        //yield return new WaitForSeconds(3);
        ball.Reset();
        IsLegalRegion = true;
    }
    

}
