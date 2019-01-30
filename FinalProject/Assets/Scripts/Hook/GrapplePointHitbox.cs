using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePointHitbox : MonoBehaviour {


    public GameObject grapplePoint;
    bool isBeingProjected;

    public Vector3 EnableProjection()
    {
        grapplePoint.GetComponent<Renderer>().enabled = false;
        isBeingProjected = true;

        return grapplePoint.transform.position;
    }

    public void DisableProjection()
    {
        grapplePoint.GetComponent<Renderer>().enabled = true;
        isBeingProjected = false;
        
    }

}
