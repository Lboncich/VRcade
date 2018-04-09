using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour {

    public GameObject score;
    public GameObject playerName;
    public GameObject rank;

    public void SetScore(string rank, string name, string score)
    {
        this.rank.GetComponent<Text>().text = rank;
        this.playerName.GetComponent<Text>().text = name;
        this.score.GetComponent<Text>().text = score;
    }
}
