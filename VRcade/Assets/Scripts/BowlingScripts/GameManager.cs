using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    Bowling fullGame;
	// Use this for initialization
	void Start () {
        fullGame = new global::Bowling();
        fullGame.startFirstFrame();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
