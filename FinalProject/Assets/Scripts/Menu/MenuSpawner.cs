using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawner : MonoBehaviour {

    bool touchControllersAreTouching;

    bool hasSpawnedMenu = false;

    public GameObject menuPrefab;
    GameObject menuInstance = null;

    Vector3 pointA;
    Vector3 pointB;
    Vector3 initialPoint;

    [SerializeField]
    float distanceBetween = 0.05f;
    [SerializeField]
    float menuThickness;

    public Transform playerHead;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasSpawnedMenu)
        {
            if (touchControllersAreTouching)
            {

                if (TouchHandler.TH.RightTouchAButtonDown() && TouchHandler.TH.rightTouchPrimaryIndexTriggerPulled
                    && TouchHandler.TH.LeftTouchAButtonDown() && TouchHandler.TH.leftTouchPrimaryIndexTriggerPulled)
                {
                    menuInstance = GameObject.Instantiate(menuPrefab);
                    hasSpawnedMenu = true;

                    pointA = TouchHandler.TH.LeftTouchPosition();
                    pointB = TouchHandler.TH.RightTouchPosition();

                    Vector3 between = (pointB - pointA);
                    //float distance = between.magnitude;
                    //menuInstance.transform.localScale  = new Vector3(  distance, menuInstance.transform.localScale.y, menuInstance.transform.localScale.z);

                    initialPoint = pointA + (between * distanceBetween);
                    transform.forward = playerHead.forward;
                    transform.position = playerHead.position;
                }

            }
        }
        else
        {
            if (TouchHandler.TH.RightTouchAButtonDown() && TouchHandler.TH.rightTouchPrimaryIndexTriggerPulled
                    && TouchHandler.TH.LeftTouchAButtonDown() && TouchHandler.TH.leftTouchPrimaryIndexTriggerPulled)
            {
                pointA = TouchHandler.TH.LeftTouchPosition();
                pointB = TouchHandler.TH.RightTouchPosition();

                Vector3 between = (pointB - pointA);
                between = transform.TransformDirection(between);
                //float distance = between.magnitude;
                //menuInstance.transform.localScale  = new Vector3(  distance, menuInstance.transform.localScale.y, menuInstance.transform.localScale.z);
                menuInstance.transform.localScale = new Vector3( between.x, between.y, menuThickness);
                menuInstance.transform.position = initialPoint;

                menuInstance.transform.LookAt(playerHead);
            } else
            {
                hasSpawnedMenu = false;
                menuInstance = null;
            }
        }

    }

    public void SetTouchControllersAreTouching(bool controllersTouching)
    {
        touchControllersAreTouching = controllersTouching;
        
    }


}
