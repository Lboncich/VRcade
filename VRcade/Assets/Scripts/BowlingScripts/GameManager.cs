using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private Bowling bowlingGame;

    public GameObject startingLine;
    public BowlingBall ball;
    public Pins pins;
    public GameObject notificationCanvas;
    public GameObject highScoreCanvas;

    private bool isRunning = false;
    private int currentFrame;
    
    public int Score
    {
        get; private set;
    }

    public bool IsValidThrow
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
        IsValidThrow = false;
        currentFrame = 0;
        Score = 0;

    }
    // Update is called once per frame
    void Update () {

       if (!bowlingGame.IsGameOver)
       {
            //check if the ball crosses the starting line
            CheckValidRoll();

            //check if the ball needs to be reset
            if ((!IsLegalRegion) ||
                ((ball.GetComponent<Rigidbody>().velocity == Vector3.zero) && IsValidThrow))
            {
                StartCoroutine(Resetball());
            }



            ///if (IsValidThrow)
            //{
            //    if (!isRunning)
            //    {
            //        CheckPins();

            //    }

            //    //bowlingGame.ApplyMove(pins.NumPinsDown);
            //}
        }
        else
        {
            enabled = false;
            Debug.Log("Game over");
            Score = bowlingGame.Score;
            bool isHighScore = FindObjectOfType<HighScoreManager>().IsHighScore(Score);
            if (isHighScore)
            {
                Debug.Log("Is high score");

                highScoreCanvas.transform.Find("HighScore Notification Background").gameObject.
                    transform.Find("SCORE").gameObject.GetComponent<TextMeshProUGUI>().SetText(Score.ToString());
                highScoreCanvas.transform.Find("HighScore Notification Background").gameObject.SetActive(true);
            }
            else{
                Debug.Log("Is not high score");
                highScoreCanvas.transform.Find("Score Notification Background").gameObject.
                    transform.Find("SCORE").gameObject.GetComponent<TextMeshProUGUI>().SetText(Score.ToString());
                highScoreCanvas.transform.Find("Score Notification Background").gameObject.SetActive(true);
            }

        }
        


        //GameObject bowlingball = GameObject.Find("Bowling_Ball");
        

        
    }

    private IEnumerator Resetball()
    {
        
        yield return new WaitForSeconds(5);
        ball.Reset();
        IsLegalRegion = true;
        IsValidThrow = false;
    }

    
    private void CheckValidRoll()
    {
        if (ball.transform.position.z < startingLine.transform.position.z)//bowling ball is in legal boundary
        {
            IsValidThrow = true;
        }
        else
            IsValidThrow = false;
    }

    public void ApplyMove()
    {
        Debug.Log("Valid Move called");
        pins.CheckPins();
        Debug.Log("Number of pins " + pins.NumPinsDown);
        bowlingGame.ApplyMove(pins.NumPinsDown);

        //Debug.Log(bowlingGame.RollType);
        if (bowlingGame.RollType == "GUTTER")
        {
            ActivateObject(notificationCanvas.transform.Find("Gutter").gameObject);
            FindObjectOfType<AudioManager>().Play("Gutter");
            StartCoroutine(DeactivateObject(notificationCanvas.transform.Find("Gutter").gameObject));
            //notificationCanvas.transform.Find("Gutter").gameObject.SetActive(true);
        }else if(bowlingGame.RollType == "SPARE")
        {
            ActivateObject(notificationCanvas.transform.Find("Spare").gameObject);
            StartCoroutine(DeactivateObject(notificationCanvas.transform.Find("Spare").gameObject));
            //notificationCanvas.transform.Find("Spare").gameObject.SetActive(true);
        }
        else if(bowlingGame.RollType == "STRIKE")
        {
            ActivateObject(notificationCanvas.transform.Find("Strike").gameObject);
            StartCoroutine(DeactivateObject(notificationCanvas.transform.Find("Strike").gameObject));
            //notificationCanvas.transform.Find("Strike").gameObject.SetActive(true);
        }
        else
        {
            notificationCanvas.transform.Find("Score").gameObject.
                    transform.Find("SCORE").gameObject.GetComponent<TextMeshProUGUI>().SetText(pins.NumPinsDown.ToString());
            ActivateObject(notificationCanvas.transform.Find("Score").gameObject);
            //FindObjectOfType<AudioManager>().Play("Score");
            StartCoroutine(DeactivateObject(notificationCanvas.transform.Find("Score").gameObject));
        }
        if (currentFrame != bowlingGame.CurrentFrame)
        {
            Debug.Log(bowlingGame.CurrentFrame);
            StartCoroutine(pins.Reset());
            //pins.Reset();
            currentFrame = bowlingGame.CurrentFrame;
        }
        else
        {
            Debug.Log("Here");
        }
    }

    private void ActivateObject(GameObject g)
    {
        g.SetActive(true);
    }

    private IEnumerator DeactivateObject(GameObject g)
    {
        yield return new WaitForSeconds(2);
        g.SetActive(false);
    }
}
