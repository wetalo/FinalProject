using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour {
    private bool _rotate;
    private bool stopRotation = false;
    // Use this for initialization
    void Start () {
        _rotate = true;
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = GetComponent<Rigidbody>().velocity;
        if (_rotate && vel != Vector3.zero) { 
            transform.rotation = Quaternion.LookRotation(vel);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        _rotate = false;
    }

    
    void OnCollisionExit(Collision other)
    {
        if(!stopRotation)
            _rotate = true;
    }
    
    public void StopRotation()
    {
        stopRotation = true;
    }

}
