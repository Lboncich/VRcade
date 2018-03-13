using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Needed to connect to database
using System;
using System.Data;
using Mono.Data.Sqlite;


public class DatabaseManager : MonoBehaviour {

    private string connectionString;

    private Scene scene;

    private List<HighScore> highScoreList = new List<HighScore>();

	// Use this for initialization
	void Start () {

        //ActiveScene
        scene = SceneManager.GetActiveScene();
        //path to the database
        connectionString = "URI=file:" + Application.dataPath + "/Scripts/HighScore.sqlite";
        //GetScore();
	}
	
	// Update is called once per frame
	void Update () {
		
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
                string query = "SELECT * FROM "+ scene.name;

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
            

        
    }

    /// <summary>
    /// Method to insert a score to the database
    /// </summary>
    /// <param name="playerName"> Name of the player</param>
    /// <param name="score"> Score received </param>
    private void InsertScore(string playerName, int score)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            //open the database
            dbConnection.Open();

            //creating command
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string query = String.Format("INSERT INTO \"{0}\"(Name,Score)" +
                    "VALUES(\"{1}\",\"{2}\")", scene.name, playerName, score);
                
                //execute command
                dbCmd.CommandText = query;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
                
            }
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
                string query = String.Format("DELETE FROM \"{0}\" WHERE" +
                    "id = \"{0}\"", playerID);

                //execute command
                dbCmd.CommandText = query;
                dbCmd.ExecuteScalar();
                dbConnection.Close();

            }
        }
    }

    /// <summary>
    /// Display the scores 
    /// </summary>
    private void DisplayScores()
    {

    }

}
