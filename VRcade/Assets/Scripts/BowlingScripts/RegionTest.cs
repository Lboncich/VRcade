using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionTest : MonoBehaviour {
    public GameObject bowlingball;
    public GameObject region;

    private bool isLegal;

    public bool IsLegal
    {
        get; private set;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (bowlingball.transform.position.z < region.transform.position.z)//bowling ball is in legal boundary
        {
            IsLegal = true;
        }
        else
            IsLegal = false;
    }
    
}
