using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchTrigger : MonoBehaviour {
    public EventSystem eventSys;
    public GameObject selectedButton;
    private bool buttonActive;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    void onTriggerEnter(Collider obj)
    {
        Debug.Log("Hmdah hmdah ultra omega tayay hmdah");
        if (obj.tag == "GameController" && buttonActive == false)
        {
            eventSys.SetSelectedGameObject(selectedButton);
            buttonActive = true;
        }
    }
    private void OnDisable()
    {
        buttonActive = false;
    }
}
