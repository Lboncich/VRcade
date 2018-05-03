using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ToggleBumperAnimation : MonoBehaviour {
    public Animation rBumpIn;
    public Animation rBumpOut;
    public Animation lBumpIn;
    public Animation lBumpOut;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void bumpersIn()
    {
        rBumpIn = GetComponent<Animation>();
        lBumpIn = GetComponent<Animation>();
    }
    private void bumpersOut()
    {
        rBumpOut = GetComponent<Animation>();
        lBumpOut = GetComponent<Animation>();
    }
}
