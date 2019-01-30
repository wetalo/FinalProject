using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTriggerZone : MonoBehaviour {

    public bool isTouchingRightController;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "GrabVolumeSmall")
        {
            isTouchingRightController = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "GrabVolumeSmall")
        {
            isTouchingRightController = false;
        }
    }



}
