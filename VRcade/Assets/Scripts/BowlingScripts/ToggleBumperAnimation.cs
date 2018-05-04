using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ToggleBumperAnimation : MonoBehaviour {
    public Animator rBumpIn;
    public Animator rBumpOut;
    public Animator lBumpIn;
    public Animator lBumpOut;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void bumpersIn()
    {
        rBumpIn = GetComponent<Animator>();
        lBumpIn = GetComponent<Animator>();
    }
    private void bumpersOut()
    {
        rBumpOut = GetComponent<Animator>();
        lBumpOut = GetComponent<Animator>();
    }
}
