using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZTargetImage : MonoBehaviour {

    public Transform target;
    public Camera uiCam;


    public float scaleMultiplier = 1.2f;
    public float scalingTime = 0.4f;
    float scalingTimer;
    bool scalingUp;

    Vector3 defaultScale;
    Vector3 largerScale;


    
	// Use this for initialization
	void Start () {
        defaultScale = transform.localScale;
        largerScale = defaultScale * scaleMultiplier;
	}
	
	// Update is called once per frame
	void Update () {
        if (target)
        {
            Vector3 position = uiCam.WorldToScreenPoint(target.position);
            transform.position = position;

            scalingTimer += Time.deltaTime;
            if (scalingTimer > scalingTime)
            {
                scalingUp = !scalingUp;
                scalingTimer = 0f;
            }
            if (scalingUp)
            {
                transform.localScale = defaultScale - ((defaultScale - largerScale) * (scalingTimer / scalingTime));

            } else
            {
                transform.localScale = largerScale - ((largerScale - defaultScale) * (scalingTimer / scalingTime));
            }
        }
	}

    public void SetTarget(Transform target)
    {
        this.target = target;
        scalingTimer = 0f;
    }
}
