﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //private Bowling fullGame;
    private GameObject bowlingball;
    public GameObject region;

    private bool isLegal;

    public bool IsLegal
    {
        get; private set;
    }
    // Use this for initialization
    void Start () {
       // fullGame = new global::Bowling();
       // fullGame.startFirstFrame();
	}
	
	// Update is called once per frame
	void Update () {
        bowlingball = GameObject.Find("Bowling_Ball");
        if (bowlingball.transform.position.z < region.transform.position.z)//bowling ball is in legal boundary
        {
            IsLegal = true;
            
        }
        else
            IsLegal = false;
        Debug.Log("Value of legal: "+IsLegal);
    }
}
