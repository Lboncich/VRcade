using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Needed to connect to database
using System;
using System.Data;
using Mono.Data.Sqlite;


public class HighScoreManager : MonoBehaviour
{

    private string connectionString;

    private Scene scene;
    private string tableName;

    private List<HighScore> highScoreList = new List<HighScore>();

    public GameObject scorePrefab;
    
    public Transform scoreParent;

    // Use this for initialization
    public void Start()
    {

        //ActiveScene
        scene = SceneManager.GetActiveScene();

        //Determine the tablename
        if (scene.name == "BowlingScene")
        {
            tableName = "Bowling";
        }
        else
        {
            tableName = "";
        }

        Debug.Log("Database Manager Started");
        //path to the database
        connectionString = "URI=file:" + Application.dataPath + "/HighScore.s3db";

        
        ShowScores();
    }

    /// <summary>
    /// Method to extract score from the database
    /// </summary>
    private void GetScore()
    {
        //Clear the list
        highScoreList.Clear();

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            //open the database
            dbConnection.Open();

            //creating command
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string query = "SELECT * FROM " + tableName;
                dbCmd.CommandText = query;

                //executes the command and saves it to the reader
                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        highScoreList.Add(new HighScore(reader.GetInt32(0), reader.GetString(1),
                            reader.GetInt32(2), reader.GetDateTime(3)));
                    }

                    reader.Close();
                    dbConnection.Close();

                }
            }
        }

        //sort the scores inorder to remove scores more than 20
        highScoreList.Sort();


    }

    /// <summary>
    /// Method to insert a score to the database
    /// </summary>
    /// <param name="playerName"> Name of the player</param>
    /// <param name="score"> Score received </param>
    public void InsertScore(string playerName, int score)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            //open the database
            dbConnection.Open();

            //creating command
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string query = String.Format("INSERT INTO \"{0}\"(Name,Score)" +
                    "VALUES(\"{1}\",\"{2}\")", tableName, playerName, score);

                //execute command
                dbCmd.CommandText = query;
                dbCmd.ExecuteScalar();
                dbConnection.Close();

            }
        }

        if (highScoreList.Count > 20)
        {
            
            //playerID of the last highscore in the table
            int playerID = highScoreList[highScoreList.Count - 1].Id;

            RemoveScore(playerID);
        }

    }

    /// <summary>
    /// remove a particular row from the database based on the playerID provided
    /// </summary>
    /// <param name="playerID">A unique identifier to the row</param>
    private void RemoveScore(int playerID)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            //open the database
            dbConnection.Open();

            //creating command
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string query = String.Format("DELETE FROM \"{0}\" WHERE " +
                    "id = \"{1}\"", tableName,playerID);

                //execute command
                dbCmd.CommandText = query;
                dbCmd.ExecuteScalar();
                dbConnection.Close();

            }
        }
    }

    /// <summary>
    /// Return the top 20 high scores.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<HighScore> GetHighScoreList()
    {
        highScoreList.Sort();
        return highScoreList;
    }

    /// <summary>
    /// Checks if the score provided is high enough to make to high score
    /// </summary>
    /// <returns><c>true</c>, if score is high enouhg, <c>false</c> otherwise.</returns>
    /// <param name="score"> score obtained by the user</param>
    public Boolean IsHighScore(int score)
    {

        GetScore();
        if (highScoreList.Count < 20)
        {
            return true;
        }
        foreach (HighScore highscore in highScoreList)
        {
            if (score >= highscore.Score)
            {
                Debug.Log("Here");
                return true;
            }

        }
        return false;
    }

    /// <summary>
    /// To assign scores from database to the score prefab and display it 
    /// </summary>
    public void ShowScores()
    {

        GetScore();
        DeleteChildren();
        for (int i = 0; i < highScoreList.Count; i++)
        {
            GameObject tempObject = GameObject.Instantiate(scorePrefab);

            HighScore tempScore = highScoreList[i];

            var nameObject = tempObject.GetComponentInChildren<Transform>().Find("Name").gameObject;
            var rankObject = tempObject.GetComponentInChildren<Transform>().Find("Rank").gameObject;
            var scoreObject = tempObject.GetComponentInChildren<Transform>().Find("Score").gameObject;
            tempObject.GetComponent<HighScoreScript>().Assign(rankObject, nameObject, scoreObject);

            tempObject.GetComponent<HighScoreScript>().SetScore((i + 1).ToString(), tempScore.PlayerName, tempScore.Score.ToString());
            //
            //set the parent of each score to be "SCORES" object so everything is under it
            tempObject.transform.SetParent(scoreParent);


            tempObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

            var xPosition = tempObject.transform.position.x;
            var yPosition = tempObject.transform.position.y;
            var zPosition = 0;

            tempObject.GetComponent<RectTransform>().localPosition = new Vector3(xPosition, yPosition, zPosition);
        }
       
    }

    /// <summary>
    /// Destroy all existing child object before adding
    /// </summary>
    private void DeleteChildren()
    {

        foreach (Transform child in scoreParent)
        {
            Destroy(child.gameObject);
        }
    }
}
