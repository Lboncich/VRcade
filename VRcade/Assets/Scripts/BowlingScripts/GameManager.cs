﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    public GameObject region;

    private bool isLegal;
    private Frame[] frameList = new Frame[10];
    private bool IsBonusCalculationDone = true;
    private int bonusPoint = 0;
    private int index = 0;

    public bool IsLegal
    {
        get; private set;
    }

    public int CurrentRoll
    {
        get; private set;
    }

    public int CurrentFrame
    {
        get; private set;
    }

    public bool IsGameOver
    {
        get
        {
            return (CurrentFrame >= 10) ? true : false;
        }
    }

    public int Score
    {
        get; private set;
    }

    public string RollType
    {
        get; private set;
    }

    // Update is called once per frame
    void Update () {

        GameObject bowlingball = GameObject.Find("Bowling_Ball");
        if (bowlingball.transform.position.z < region.transform.position.z)//bowling ball is in legal boundary
        {
            IsLegal = true;
            
        }
        else
            IsLegal = false;
        //Debug.Log("Value of legal: "+IsLegal);
    }

    public GameManager()
    {
        for (int i = 0; i < 10; i++)
        {
            frameList[i] = new Frame(i + 1);

        }

        CurrentRoll = 0;
        CurrentFrame = 0;
    }

    public void ApplyMove(int numPins)
    {
        if (!IsBonusCalculationDone)
        {
            /*if (frameList[CurrentFrame - 1].IsStrike)
            {
                bonusPoint += numPins;
                index++;
                if (index == 2)
                {
                    IsBonusCalculationDone = true;
                    index = 0;
                    frameList[CurrentFrame - 1].UpdateScore(Score, bonusPoint);
                    Score = frameList[CurrentFrame - 1].FrameScore;
                    bonusPoint = 0;
                }
                //if (index <= 1)
                //{
                //    bonusPoint += numPins;
                //    index++;
                //}
                //else
                //{
                //    IsBonusCalculationDone = true;
                //    index = 0;
                //    bonusPoint = 0;
                //}
            }
            else
            {*/
            bonusPoint = numPins;
            frameList[CurrentFrame - 1].UpdateScore(Score, bonusPoint);
            Score = frameList[CurrentFrame - 1].FrameScore;
            IsBonusCalculationDone = true;
            //}

        }

        frameList[CurrentFrame].Roll(numPins);
        UpdateRollType();

        if (frameList[CurrentFrame].CurrentRoll > 1)
        {

            if (((frameList[CurrentFrame].IsSpare) || (frameList[CurrentFrame].IsStrike)) && CurrentFrame < 9)
            {
                IsBonusCalculationDone = false;
            }
            else
            {
                frameList[CurrentFrame].UpdateScore(Score);
                Score = frameList[CurrentFrame].FrameScore;
            }

            CurrentFrame++;
            CurrentRoll = 0;
        }
        else
        {
            CurrentRoll++;
        }


    }

    public int GetFrameScore(int frameNumber)
    {
        return frameList[frameNumber].FrameScore;
    }

    private void UpdateRollType()
    {
        if (frameList[CurrentFrame].IsStrike)
        {
            RollType = "STRIKE";
        }
        else if (frameList[CurrentFrame].IsSpare)
        {
            RollType = "SPARE";
        }
        else if (frameList[CurrentFrame].IsRollGutter(CurrentRoll))
        {
            RollType = "GUTTER";
        }
        else
        {
            RollType = "NORMAL";
        }
    }

}
