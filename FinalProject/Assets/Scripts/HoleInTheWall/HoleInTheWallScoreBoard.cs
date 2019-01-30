using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoleInTheWallScoreBoard : MonoBehaviour {

    public Text scoreboardText;
    public Text winText;
    public Text lossText;

    public FloatVariable wins;
    public FloatVariable losses;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeCounter(FloatVariable newNumber)
    {
        int number = (int)(Mathf.Ceil(newNumber.Value));
        scoreboardText.text = "" + number;
    }

    public void BeatGame()
    {
        scoreboardText.text = "Yay you won";
    }

    public void NewLevel()
    {
        winText.text = "Wins: " + wins.Value;
        lossText.text = "Losses: " + losses.Value;
    }
}
