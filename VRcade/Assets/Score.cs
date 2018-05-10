using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    private Transform hs;
    private Transform sn;
    private Transform kb;
    private Transform HSNB;
    // Use this for initialization
    void Start () {
        hs = transform.Find("HighScore Background");
        hs.gameObject.SetActive(false);
        sn = transform.Find("Score Notification Background");
        sn.gameObject.SetActive(false);
        kb = transform.Find("Keyboard Background");
        kb.gameObject.SetActive(false);
        HSNB = transform.Find("HighScore Notification Background");
        HSNB.gameObject.SetActive(false);


        //Transform[] allChildren = GetComponentsInChildren<Transform>();
        //foreach (Transform child in allChildren)
        //{
        //    child.gameObject.SetActive(false);
        //}
        //gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
