using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float spinSpeed;

     enum RotationAxis
    {
        Up,
        Forward,
        Right
    }

    [SerializeField]
     RotationAxis rotationAxis;

    Vector3 rotationVector;

	// Use this for initialization
	void Start () {
		switch (rotationAxis)
        {
            case RotationAxis.Up:
                rotationVector = transform.up;
                break;
            case RotationAxis.Forward:
                rotationVector = transform.forward;
                break;
            case RotationAxis.Right:
                rotationVector = transform.right;
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {

        transform.RotateAround(transform.position, rotationVector, spinSpeed * Time.deltaTime);
    }
}
