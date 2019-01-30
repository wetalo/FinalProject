using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleBarrier : MonoBehaviour {

    bool touchedBarrier = false;
    public GameEvent touchedBarrierEvent;
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
            touchedBarrier = true;
        }
        if (other.name == "GrabberColliderRight")
        {
            touchedBarrier = true;
        }
        if (other.name == "HeadCollider")
        {
            touchedBarrier = true;
        }

        if (touchedBarrier)
        {
            touchedBarrierEvent.Raise();
        }

    }
}
