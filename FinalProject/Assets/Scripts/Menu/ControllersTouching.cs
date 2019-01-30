using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllersTouching : MonoBehaviour {

    public GameEvent controllersTouching;
    public GameEvent controllersNotTouching;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "GrabberCollider")
        {
            controllersTouching.Raise();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "GrabberCollider")
        {
            controllersNotTouching.Raise();
        }
    }
}
