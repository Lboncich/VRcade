using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeTextOnHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Color32 desiredColor;
    public Color32 originalColor;
    public Text textToChange;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnPointerEnter(PointerEventData eventData)
    {
        textToChange.color = desiredColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textToChange.color = originalColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        textToChange.color = originalColor;
    }
}
