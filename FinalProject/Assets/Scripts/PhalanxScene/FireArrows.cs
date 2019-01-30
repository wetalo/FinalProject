using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrows : MonoBehaviour {


    public GameObject[] arrows;
    public float arrowFireForce;
	// Use this for initialization
	void Start () {
		foreach (GameObject arrow in arrows)
        {
            arrow.GetComponent<Rigidbody>().isKinematic = false;
            arrow.GetComponent<Rigidbody>().AddForce(arrow.transform.forward * arrowFireForce, ForceMode.Impulse);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
