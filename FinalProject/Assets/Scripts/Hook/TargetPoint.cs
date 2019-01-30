using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPoint : MonoBehaviour {

    public Material targetPointValid;
    public Material targetPointInvalid;

    public Vector3 point;
    public bool valid;

    Renderer myRenderer;

	// Use this for initialization
	void Start () {
        myRenderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = point;

    }

    public void SetValid(bool valid)
    {
        this.valid = valid;

        
        if (valid)
        {
            myRenderer.material = targetPointValid;
        } else
        {
            myRenderer.material = targetPointInvalid;
        } 
    }

    public void SetPosition(Vector3 position)
    {
        this.point = position;
    }
}
