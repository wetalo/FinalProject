using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour {

    OVRGrabbable grabbable;
    OVRGrabber grabbedBy;
    CharacterScript playerScript;

    enum JetpackStates
    {
        idle,
        jetpacking
    }

    JetpackStates state = JetpackStates.idle;
    

	// Use this for initialization
	void Start () {
        grabbable = GetComponent<OVRGrabbable>();
        playerScript = GameObject.Find("LocalAvatarWithGrab").GetComponent<CharacterScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (grabbable.isGrabbed)
        {
            grabbedBy = grabbable.grabbedBy;
            bool triggerPulled = false;
            if(grabbedBy.name == "AvatarGrabberLeft")
            {
                triggerPulled = TouchHandler.TH.leftTouchPrimaryIndexTriggerPulled;
            } else if (grabbedBy.name == "AvatarGrabberRight")
            {
                triggerPulled = TouchHandler.TH.rightTouchPrimaryIndexTriggerPulled;
            }
            if (triggerPulled)
            {
                Propel();
            } 
        }
	}

    void Propel()
    {
        if (grabbedBy.name == "AvatarGrabberLeft")
        {
        }
        else if (grabbedBy.name == "AvatarGrabberRight")
        {
        }
    }
}
