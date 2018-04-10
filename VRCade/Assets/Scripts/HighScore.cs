using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HighScore : MonoBehaviour, IComparable{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    

    public int Id { get; set; }
    public string PlayerName { get; set; }
    public int Score { get; set; }
    public DateTime Date { get; set; }

    //Constructor to initialize the data
    public HighScore(int id, string name, int score, DateTime date)
    {
        Id = id;
        PlayerName = name;
        Score = score;
        Date = date;
    }

    public int CompareTo(object obj)
    {
        HighScore hs = obj as HighScore;

        if (this.Score > hs.Score)
        {
            return 1;
        }
        else if (this.Score < hs.Score)
        {
            return -1;
        }
        else if (this.Date > hs.Date)
        {
            return 1;
        }
        else if (this.Date < hs.Date)
        {
            return -1;
        }

        return 0;
    }
}
