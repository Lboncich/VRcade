
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using System;

public class EventListener : MonoBehaviour
    {
    public GameObject bb;
    public List<GameObject> bbs;
    System.Random rnd = new System.Random();
    private void Start()
    {
        
        if (GetComponent<VRTK_ControllerEvents>() == null)
        {
            VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerEvents_ListenerExample", "VRTK_ControllerEvents", "the same"));
            return;
        }
        GetComponent<VRTK_ControllerEvents>().ButtonOneTouchStart += new ControllerInteractionEventHandler(DoButtonOneTouchStart);
        GetComponent<VRTK_ControllerEvents>().ButtonOneTouchEnd += new ControllerInteractionEventHandler(DoButtonOneTouchEnd);
    }
        private void DoButtonOneTouchStart(object sender, ControllerInteractionEventArgs e)
        {
  
        Destroy(GameObject.FindGameObjectWithTag("BowlingBall"));
        int rndint= rnd.Next(0, 1);
        Debug.Log(rndint);
       GameObject randomBB = bbs[rndint];
            
        
        Instantiate(randomBB, new Vector3(-0.557f,1.0f, -1.145f), Quaternion.identity);
        DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "BUTTON ONE", "touched", e);
        }

        private void DoButtonOneTouchEnd(object sender, ControllerInteractionEventArgs e)
        {
            DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "BUTTON ONE", "untouched", e);
        }
    private void DebugLogger(uint index, string button, string action, ControllerInteractionEventArgs e)
    {
        VRTK_Logger.Info("Controller on index '" + index + "' " + button + " has been " + action
                + " with a pressure of " + e.buttonPressure + " / trackpad axis at: " + e.touchpadAxis + " (" + e.touchpadAngle + " degrees)");
    }

    //Setup controller event listeners

}