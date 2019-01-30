using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchHandler : MonoBehaviour {

    public static TouchHandler TH;

    #region PrimaryHandTrigger
    public bool rightTouchPrimaryHandTriggerPulled;
    public bool leftTouchPrimaryHandTriggerPulled;
    #endregion

    #region PrimaryIndexTrigger
    public bool rightTouchPrimaryIndexTriggerPulled;
    public bool leftTouchPrimaryIndexTriggerPulled;
    #endregion
    

    

    void Awake()
    {
        //Singleton pattern
        if (TH == null)
        {
            DontDestroyOnLoad(gameObject);
            TH = this;
        }
        else if (TH != this)
        {
            Destroy(gameObject);
        }
    }

        // Use this for initialization
    void Start () {
        rightTouchPrimaryHandTriggerPulled = false;
        leftTouchPrimaryHandTriggerPulled = false;

        rightTouchPrimaryIndexTriggerPulled = false;
        leftTouchPrimaryIndexTriggerPulled = false;
    }
	
	// Update is called once per frame
	void Update () {

        CheckTouchPrimaryHandTriggers();
        CheckTouchPrimaryIndexTriggers();


       
        
    }

    void CheckTouchPrimaryHandTriggers()
    {
        if (!rightTouchPrimaryHandTriggerPulled && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch) > 0.0f)
        {
            rightTouchPrimaryHandTriggerPulled = true;
        }

        if (rightTouchPrimaryHandTriggerPulled && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch) == 0.0f)
        {
            rightTouchPrimaryHandTriggerPulled = false;
        }

        if (!leftTouchPrimaryHandTriggerPulled && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) > 0.0f)
        {
            leftTouchPrimaryHandTriggerPulled = true;
        }

        if (leftTouchPrimaryHandTriggerPulled && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) == 0.0f)
        {
            leftTouchPrimaryHandTriggerPulled = false;
        }

    }

    void CheckTouchPrimaryIndexTriggers()
    {
        if (!rightTouchPrimaryIndexTriggerPulled && OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > 0.0f)
        {
            rightTouchPrimaryIndexTriggerPulled = true;
        }

        if (rightTouchPrimaryIndexTriggerPulled && OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) == 0.0f)
        {
            rightTouchPrimaryIndexTriggerPulled = false;
        }

        if (!leftTouchPrimaryIndexTriggerPulled && OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch) > 0.0f)
        {
            leftTouchPrimaryIndexTriggerPulled = true;
        }

        if (leftTouchPrimaryIndexTriggerPulled && OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch) == 0.0f)
        {
            leftTouchPrimaryIndexTriggerPulled = false;
        }

    }

    public bool RightTouchAButtonDown()
    {
        return OVRInput.Get(OVRInput.Button.One);
    }

    public bool LeftTouchAButtonDown()
    {
        return OVRInput.Get(OVRInput.Button.Three);
    }

    public Vector3 RightTouchLocalPosition()
    {
        return OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
    }

    public Vector3 LeftTouchLocalPosition()
    {
        return OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
    }

    public Vector3 RightTouchPosition()
    {
        return GameObject.Find("AvatarGrabberRight").transform.position;
    }

    public Vector3 LeftTouchPosition()
    {
        return GameObject.Find("AvatarGrabberLeft").transform.position;
    }


}
