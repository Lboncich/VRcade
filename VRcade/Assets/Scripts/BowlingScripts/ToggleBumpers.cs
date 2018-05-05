using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBumpers : MonoBehaviour {
    [SerializeField]
    private GameObject right_bumper;
    [SerializeField]
    private GameObject left_bumper;
    private bool toggleFlag;
	// Use this for initialization
	void Start () {
        toggleFlag = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// Looks at the toggleFlag boolean to determine how to turn off/on the two lane-bumpers.
    /// false => bumpers are currently off. true => bumpers are currently on.
    /// </summary>
    public void toggleBumpers()
    {
        if(toggleFlag == false)
        {
            turnOn();
            toggleFlag = true;
        }
        else
        {
            turnOff();
            toggleFlag = false;
        }
    }
    private void turnOn()
    {
        right_bumper.SetActive(true);
        left_bumper.SetActive(true);
    }
    private void turnOff()
    {
        right_bumper.SetActive(false);
        left_bumper.SetActive(false);
    }
}
