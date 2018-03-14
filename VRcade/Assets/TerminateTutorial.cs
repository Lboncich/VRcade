using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;
public class TerminateTutorial : MonoBehaviour {

    public VRTK_ControllerEvents rightController;
    public Canvas tutCanvas;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
	}
    void terminateTutorial()
    {
        if(rightController.buttonOnePressed == true)
        {
            tutCanvas.gameObject.SetActive() = false;
        }
    }
}
