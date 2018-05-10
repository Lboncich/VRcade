

using UnityEngine;
using VRTK;

public class EventListener : MonoBehaviour
    {
    
    public GameObject pauseCanvas;
    private bool switcher = true;
    private void Start()
    {
        
        if (GetComponent<VRTK_ControllerEvents>() == null)
        {
            VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerEvents_ListenerExample", "VRTK_ControllerEvents", "the same"));
            return;
        }
       // GetComponent<VRTK_ControllerEvents>().ButtonOneTouchStart += new ControllerInteractionEventHandler(DoButtonOneTouchStart);
        //GetComponent<VRTK_ControllerEvents>().ButtonOneTouchEnd += new ControllerInteractionEventHandler(DoButtonOneTouchEnd);
        GetComponent<VRTK_ControllerEvents>().ButtonTwoPressed += new ControllerInteractionEventHandler(DoButtonTwoTouched);
        GetComponent<VRTK_ControllerEvents>().ButtonOnePressed += new ControllerInteractionEventHandler(TerminateTutorialCanvas);

    }
    private void TerminateTutorialCanvas(object sender, ControllerInteractionEventArgs e)
    {
        GameObject tutCanvas = GameObject.FindGameObjectWithTag("Tutorial");
        switcher = false;
        tutCanvas.gameObject.SetActive(false);
    }
    private void DoButtonTwoTouched(object sender, ControllerInteractionEventArgs e)
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseCanvas.SetActive(true);
        }else if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseCanvas.SetActive(false);
        }
    }
    private void DoButtonOneTouchStart(object sender, ControllerInteractionEventArgs e)
    { 
        //GameObject ball = GameObject.FindGameObjectWithTag("BowlingBall");
        //int rndint= rnd.Next(0, 2);
        //Debug.Log(rndint);
        //GameObject randomBB = bbs[rndint];
        //bb = bbs[rndint];
        //Debug.Log("Where");
        //bb.Reset();
        // DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "BUTTON ONE", "touched", e);
    }
    private void DoButtonOneTouchEnd(object sender, ControllerInteractionEventArgs e)
    {
        //DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "BUTTON ONE", "untouched", e);
    }
    private void DebugLogger(uint index, string button, string action, ControllerInteractionEventArgs e)
    {
        VRTK_Logger.Info("Controller on index '" + index + "' " + button + " has been " + action
                + " with a pressure of " + e.buttonPressure + " / trackpad axis at: " + e.touchpadAxis + " (" + e.touchpadAngle + " degrees)");
    }

    //Setup controller event listeners

}