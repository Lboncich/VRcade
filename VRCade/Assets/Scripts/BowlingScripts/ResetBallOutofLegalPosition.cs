using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBallOutofLegalPosition : MonoBehaviour {
    
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "Bowling_Ball")
        {
            bool isValid = FindObjectOfType<GameManager>().IsValidThrow;
            if (isValid)
            {
                
                StartCoroutine(FindObjectOfType<GameManager>().ApplyMove());
            }
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
