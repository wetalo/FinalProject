using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {

    enum CharacterStates
    {
        idle,
        jetpacking
    }

    CharacterStates state = CharacterStates.idle;
    CharacterController myController;

    //Gravity
    public float gravity = -9.8f; //meters per second per second
    private float terminalYVelocity = -53f; //meters per second

    //movement
    private float myXVelocity = 0.0f;
    private float myZVelocity = 0.0f;
    private float myYVelocity = 0.0f;

    private Vector3 moveDirection = Vector3.zero;

    // Use this for initialization
    void Start () {
        myController = GetComponent<CharacterController>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        Gravity();
        RunStates();
	}



    void RunStates()
    {

    }

    void LateUpdate()
    {
        //Set direction
        moveDirection = transform.TransformDirection(new Vector3(myXVelocity, myYVelocity, myZVelocity));

        //moveDirection = new Vector3(myXVelocity, myYVelocity, 0);

        //apply movement
        myController.Move(moveDirection * Time.deltaTime);
    }

    void Gravity()
    {
        if (!myController.isGrounded)
        {

            if (myYVelocity > terminalYVelocity)
            {
                myYVelocity += gravity * Time.deltaTime;
            }
            else
            {
                myYVelocity = terminalYVelocity;
            }

        }
        else
        {
            myYVelocity = -1;
        }
    }
}
