using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardScript : MonoBehaviour {

    // Use this for initialization
    //public Button button = null;
    
    public string Name;
    public Text texbox;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Name);
	}

    public void getText(Button b)
    {
        Name += b.name;
        texbox.text += name;
        //Debug.Log(b.name);
      //  string text = b.GetComponentInChildren<Text>().text.ToString();

        //Debug.Log(text);
    }
}
