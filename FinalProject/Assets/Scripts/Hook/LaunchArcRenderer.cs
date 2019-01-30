using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class LaunchArcRenderer : MonoBehaviour {
    LineRenderer lr;

    public float velocity;
    public float angle;
    public int resolution = 10;

    float g; // force of gravity on y axis
    float radianAngle;


    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        g = Mathf.Abs(Physics2D.gravity.y);
    }

    private void OnValidate()
    {
        //Check that lr is not null and that the game is playing
        if(lr != null  && Application.isPlaying)
        {
            RenderArc();
        }
    }

    // Use this for initialization
    void Start () {
        RenderArc();
	}
	
    //Populating the LineRenderer with the appropriate settings
    void RenderArc()
    {
        lr.positionCount = (resolution + 1);
        lr.SetPositions(CalculateArcArray());
    }

    Vector3[] CalculateArcArray()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];
        radianAngle = Mathf.Deg2Rad * angle;

        float maxDistance = (velocity * velocity * Mathf.Sin(2*radianAngle))/g;

        for(int i=0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            arcArray[i] = CalculateArcPoint(t, maxDistance);
        }
        return arcArray;
    }

    Vector3 CalculateArcPoint(float t, float maxDistance)
    {
        float x = t * maxDistance;
        float y = x * Mathf.Tan(radianAngle) - ((g * x * x) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));
        float z = 0;
        Vector3 arcPoint = new Vector3(x,y,z);
        return arcPoint;
    }
}
