using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicOnSpawn : MonoBehaviour {

    [SerializeField]
    float timeToBeKinematic;
    float kinematicTimer = 0f;
    OVRGrabbable grabbable;
	// Use this for initialization
	void Start () {
        grabbable = GetComponent<OVRGrabbable>();
	}
	
	// Update is called once per frame
	void Update () {
        kinematicTimer += Time.deltaTime;
        if(kinematicTimer > timeToBeKinematic && !grabbable.isGrabbed)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
	}
}
