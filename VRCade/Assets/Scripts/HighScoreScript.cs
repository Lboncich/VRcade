using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{

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
        this.Name.GetComponent<TextMeshProUGUI>().text = name;
        this.Score.GetComponent<TextMeshProUGUI>().text = score;
        this.Rank.GetComponent<TextMeshProUGUI>().text = rank;
    }
}
