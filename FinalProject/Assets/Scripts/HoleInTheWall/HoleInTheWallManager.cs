using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleInTheWallManager : MonoBehaviour {

    enum ManagerStates
    {
        countingDown,
        doingLevel,
        paused
    }

    ManagerStates state = ManagerStates.countingDown;

    public float timeBetweenLevels;
    public FloatVariable counter;
    int counterRounded;
    int prevCounterRounded;

    public GameEvent changeCounter;
    public GameEvent beginLevel;

    public FloatVariable numWins;
    public FloatVariable numLosses;

    bool wonLevel;
    bool lostLevel;

	// Use this for initialization
	void Start () {
        numWins.Value = 0f;
        numLosses.Value = 0f;
        BeginCountDown();
    }
	
	// Update is called once per frame
	void Update () {
        RunStates();
	}

    void RunStates()
    {
        CountDown();
        DoingLevel();
    }


    public void BeginCountDown()
    {
        counter.Value = timeBetweenLevels;
        counterRounded = (int) Mathf.Ceil(counter.Value);
        state = ManagerStates.countingDown;
    }

    void CountDown()
    {
        if(state == ManagerStates.countingDown)
        {
            counter.Value -= Time.deltaTime;
            counterRounded = (int)Mathf.Ceil(counter.Value);

            if(prevCounterRounded != counterRounded)
            {
                changeCounter.Raise();
                prevCounterRounded = counterRounded;
            }

            if(counterRounded <= 0)
            {
                BeginLevel();
            }

        }
    }

    void BeginLevel()
    {
        state = ManagerStates.doingLevel;
        if (wonLevel)
        {
            numWins.Value++;
        }
        if (lostLevel)
        {
            numLosses.Value++;
        }
        beginLevel.Raise();
    }

    void DoingLevel()
    {

    }

    public void WonLevel()
    {
        wonLevel = true;
        lostLevel = false;
        BeginCountDown();
    }

    public void LostLevel()
    {
        wonLevel = false;
        lostLevel = true;
        BeginCountDown();
    }
}
