using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBallOutofLegalPosition : MonoBehaviour {
    
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "Bowling_Ball")
        {
            FindObjectOfType<GameManager>().IsLegalRegion = false;
            //FindObjectOfType<GameManager>().Resetball();
        }
    }

    void OnCollissionEnter( Collision col)
    {
        if (col.gameObject.name == "Bowling_Ball")
        {
            Debug.Log("Enter");
            GetComponent<GameManager>().IsLegalRegion = true;
        }
    }
}
