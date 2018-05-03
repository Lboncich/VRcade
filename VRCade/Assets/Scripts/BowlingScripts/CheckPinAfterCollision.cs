using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPinAfterCollision : MonoBehaviour {

    void OnCollissionEnter(Collision col)
    {
        if (col.gameObject.name == "Bowling_Ball")
        {
            Debug.Log("Enter");
            //StartCoroutine(GetComponent<Pins>().CheckPins());
            //GetComponent<GameManager>().IsLegalRegion = true;
        }
    }
}
