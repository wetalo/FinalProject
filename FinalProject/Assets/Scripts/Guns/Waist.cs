using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waist : MonoBehaviour {

    public bool isTouchingController;
    public GameObject controllerTouched;
    OVRGrabber grabber;
    public GameObject gunPrefab;
    bool gunSpawned = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isTouchingController)
        {
            bool triggerPulled = false;
            if (grabber.name == "AvatarGrabberLeft")
            {
                triggerPulled = TouchHandler.TH.leftTouchPrimaryHandTriggerPulled;
            }
            else if (grabber.name == "AvatarGrabberRight")
            {
                triggerPulled = TouchHandler.TH.rightTouchPrimaryHandTriggerPulled;
            }

            if (!triggerPulled)
            {
                gunSpawned = false;
            }

            if (triggerPulled && !grabber.grabbedObject && !gunSpawned)
            {
                GameObject gunInstance = GameObject.Instantiate(gunPrefab, controllerTouched.transform.position, controllerTouched.transform.rotation);
                gunSpawned = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GrabberCollider")
        {
            isTouchingController = true;
            controllerTouched = other.gameObject;

            grabber = other.transform.parent.gameObject.GetComponent<OVRGrabber>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "GrabberCollider")
        {
            isTouchingController = false;
        }
    }
}
