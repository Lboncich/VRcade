using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;
public class TerminateTutorial : MonoBehaviour {
    public VRTK_ControllerEvents rightController;
    public Canvas tutCanvas;
    private static bool switcher = true;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
        if (rightController.buttonOnePressed == true && switcher == true)
        {
            switcher = false;
            tutCanvas.gameObject.SetActive(false);
        }
    }
    //void terminateTutorial()
    //{
        
    //}
}
