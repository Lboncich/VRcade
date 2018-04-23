using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class ButtonTextHighlight : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    public Button highlightedButton;
    public Text buttonText;
    public int scene;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() { 
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = Color.black;
    }

    public void OnSelect(BaseEventData eventData)
    {
        LoadScene(scene);
    }
    public void LoadScene(int level)
    {
        Application.LoadLevel(level);
    }
}
