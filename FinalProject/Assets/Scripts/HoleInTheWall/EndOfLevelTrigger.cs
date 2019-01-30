using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevelTrigger : MonoBehaviour {

    bool wentThroughHole = false;
    bool touchedBorder = false;

    public GameEvent beatLevel;
    public GameEvent lostLevel;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       /* DebugText.DT.Debug("wentThroughHole: + " + wentThroughHole + "\n" +
                            "touchedBorder: + " + touchedBorder
                            );*/
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "HoleInTheWall")
        {
            if(wentThroughHole && !touchedBorder)
            {
                beatLevel.Raise();
            } else
            {
                lostLevel.Raise();
            }
        }
    }

    public void NewLevel()
    {
        wentThroughHole = false;
        touchedBorder = false;
    }

    public void SetWentThroughHole(bool wentThroughHole)
    {
        this.wentThroughHole = wentThroughHole;
    }

    public void SetTouchedBorder(bool touchedBorder)
    {
        this.touchedBorder = touchedBorder;
    }
}
