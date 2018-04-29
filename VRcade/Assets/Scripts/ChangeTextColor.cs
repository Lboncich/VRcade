using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeTextColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text colorChange;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("BLAH BLAH BLAH");
        colorChange.color = new Color32(0, 0, 0, 255);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        colorChange.color = new Color32(27, 118, 31, 255);
    }
}
