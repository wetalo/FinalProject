using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack2 : MonoBehaviour {

    public ParticleSystem fireParticles;

	// Use this for initialization
	void Start () {
        fireParticles.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
