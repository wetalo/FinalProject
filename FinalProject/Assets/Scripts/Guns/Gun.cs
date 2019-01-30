using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    OVRGrabbable grabbable;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    Transform muzzle;
    [SerializeField]
    float bulletSpeed;
    bool triggerReleased = true;
    

	// Use this for initialization
	void Start () {
        grabbable = GetComponent<OVRGrabbable>();
	}
	
	// Update is called once per frame
	void Update () {
        if (grabbable.isGrabbed)
        {
            OVRGrabber grabbedBy = grabbable.grabbedBy;
            bool triggerPulled = false;
            if(grabbedBy.name == "AvatarGrabberLeft")
            {
                triggerPulled = TouchHandler.TH.leftTouchPrimaryIndexTriggerPulled;
            } else if (grabbedBy.name == "AvatarGrabberRight")
            {
                triggerPulled = TouchHandler.TH.rightTouchPrimaryIndexTriggerPulled;
            }
            if (triggerPulled && triggerReleased)
            {
                Shoot();
                triggerReleased = false;
            } else if (!triggerPulled)
            {
                triggerReleased = true;
            }
        }
	}

    void Shoot()
    {

        GameObject bulletInstance = GameObject.Instantiate(bulletPrefab, muzzle.position,bulletPrefab.transform.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(bulletSpeed * muzzle.forward, ForceMode.Impulse);
    }
}
