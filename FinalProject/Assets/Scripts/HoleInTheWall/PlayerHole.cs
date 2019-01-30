using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHole : MonoBehaviour {

    bool isTouchingGrabberLeft = false;
    bool isTouchingGrabberRight = false;
    bool isTouchingHead = false;

    public GameEvent passedThroughHole;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GrabberColliderLeft")
        {
            isTouchingGrabberLeft = true;
        }
        if (other.name == "GrabberColliderRight")
        {
            isTouchingGrabberRight = true;
        }
        if (other.name == "HeadCollider")
        {
            isTouchingHead = true;
        }

        if(isTouchingGrabberLeft && isTouchingGrabberRight && isTouchingHead)
        {
            passedThroughHole.Raise();
        }
        
    }
}
