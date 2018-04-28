using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardScript : MonoBehaviour {

    private string Name;
    public TextMeshProUGUI text;

    /// <summary>
    /// Get the button's text
    /// </summary>
    /// <param name="b"></param>
    public void getText(Button b)
    {
        text.text += b.name;
    }

    /// <summary>
    /// Method that acts as a backspace
    /// </summary>
    public void BackspaceText()
    {
        string temp = text.text;
        temp=temp.Substring(0, temp.Length - 1);
        text.text = temp;
    }

    /// <summary>
    /// Record the score in the HighScore Canvas
    /// </summary>
    public void EnterName()
    {
        string playerName = text.text.Substring(0, 5);
        FindObjectOfType<HighScoreManager>().InsertScore(playerName, 700);
        //FindObjectOfType<HighScoreManager>().GetScore();
        FindObjectOfType<HighScoreManager>().ShowScores();
    }
}
