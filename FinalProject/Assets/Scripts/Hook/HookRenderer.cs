using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookRenderer : MonoBehaviour {

    public FloatVariable maxDistance;

    public GameObject targetPrefab;
    

    GameObject targetPrefabInstance;
    TargetPoint targetPoint;

    Vector3 targetPosition;

    bool isBeingProjected = false;
    GrapplePointHitbox currentGrapplePoint;

    public bool leftTouch;

    bool isZTargeting;
    public ZTargetImage zTargetImage;

	// Use this for initialization
	void Start () {
        targetPrefabInstance = GameObject.Instantiate(targetPrefab);
        targetPoint = targetPrefabInstance.GetComponent<TargetPoint>();
	}
	
	// Update is called once per frame
	void Update () {
        CastOutToTarget();
        if (isBeingProjected)
        {
            if (leftTouch)
            {
                if (TouchHandler.TH.leftTouchPrimaryHandTriggerPulled)
                {
                    zTargetImage.enabled = true;
                    zTargetImage.SetTarget(currentGrapplePoint.transform);
                    isZTargeting = true;
                } else
                {
                    zTargetImage.SetTarget(null);
                    zTargetImage.enabled = false;
                    //isBeingProjected = false;
                    isZTargeting = false;
                }
            } else
            {
                if (TouchHandler.TH.rightTouchPrimaryHandTriggerPulled)
                {
                    zTargetImage.enabled = true;
                    zTargetImage.SetTarget(currentGrapplePoint.transform);
                    isZTargeting = true;
                }
                else
                {
                    zTargetImage.SetTarget(null);
                    zTargetImage.enabled = false;
                    //isBeingProjected = false;
                    isZTargeting = false;
                }
            }
        }

    }

    void CastOutToTarget()
    {
        int layer_mask = LayerMask.GetMask("Default");
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * maxDistance.Value, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance.Value, layer_mask))
        {
            targetPosition = hit.point;
            //The object the projectile hit


            if(hit.collider.gameObject.tag == "GrapplePoint")
            {
                isBeingProjected = true;
                currentGrapplePoint = hit.collider.gameObject.GetComponent<GrapplePointHitbox>();
                targetPosition = currentGrapplePoint.EnableProjection();
                targetPoint.SetValid(true);
            } else
            {
                if (isBeingProjected)
                {
                    currentGrapplePoint.DisableProjection();
                    currentGrapplePoint = null;
                    isBeingProjected = false;
                }
                targetPoint.SetValid(false);
            }
        }
        else
        {
            if (isBeingProjected)
            {
                currentGrapplePoint.DisableProjection();
                currentGrapplePoint = null;
                isBeingProjected = false;
            }
            targetPosition = transform.position + transform.forward * maxDistance.Value;
            targetPoint.SetValid(false);
        }
        
        targetPoint.SetPosition(targetPosition);
    }
}
