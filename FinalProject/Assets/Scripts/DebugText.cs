using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour {

    public static DebugText DT;

    Text debugText;

    void Awake()
    {
        //Singleton pattern
        if (DT == null)
        {
            DontDestroyOnLoad(gameObject);
            DT = this;
        }
        else if (DT != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        debugText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Debug(string text)
    {
        debugText.text = text;
    }
}
