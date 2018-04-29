using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu;
    public VRTK_ControllerEvents buttons;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
    public void pauseControl()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showMenu();
        }else if(Time.timeScale==0){
            Time.timeScale = 1;
            hideMenu();
        }
    }
    private void showMenu()
    {
        pauseMenu.SetActive(true);
    }
    private void hideMenu()
    {
        pauseMenu.SetActive(false);
    }
    public void GripPressed()
    {

    }
}
