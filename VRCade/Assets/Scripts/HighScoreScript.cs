using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour {

    public GameObject Score;
    public GameObject Name;
    public GameObject Rank;

    public void Assign(GameObject rank, GameObject name, GameObject score)
    {
        Score = score;
        Name = name;
        Rank = rank;
    }

    public void SetScore(string rank, string name, string score)
    {
        
        this.Name.GetComponent<Text>().text = name;
        this.Score.GetComponent<Text>().text = score;
        this.Rank.GetComponent<Text>().text = rank;
    }
}
