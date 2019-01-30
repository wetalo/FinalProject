using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    bool hasCollided = false;
    [SerializeField]
    float minMagnitudeToGetStuck;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Grabbable" && !hasCollided)
        {
            Debug.Log(GetComponent<Rigidbody>().velocity.magnitude);

            if(GetComponent<Rigidbody>().velocity.magnitude > minMagnitudeToGetStuck)
            {
                GetComponent<Rigidbody>().isKinematic = true;
                transform.parent = collision.gameObject.transform;
            }
            hasCollided = true;
        }
    }
}
