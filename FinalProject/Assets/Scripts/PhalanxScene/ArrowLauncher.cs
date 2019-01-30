using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLauncher : MonoBehaviour {

    public GameObject arrowsPrefab;
    public float timeBetweenLaunches;
    float launchTimer;
	// Use this for initialization
	void Start () {
        GameObject.Instantiate(arrowsPrefab,transform.position,arrowsPrefab.transform.rotation);
        launchTimer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        launchTimer += Time.deltaTime;
        if (launchTimer > timeBetweenLaunches)
        {
            GameObject.Instantiate(arrowsPrefab, transform.position, arrowsPrefab.transform.rotation);
            launchTimer = 0f;
        }

    }
}
