using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour {

    //VARIABLES

    //Variable to set target's speed
    private float speed;
    
    private Rigidbody rb;

    //Variables to set target's start position
    private Vector2 leftStartPos;
    private Vector2 rightStartPos;

    //Variable to set target's position after restart
    private Vector2 leftRePos;
    private Vector2 rightRePos;

    //Variable to save random numbers between 0 and 1
    private float n;

    //CODE STARTS HERE

    void Awake()
    {
        //Create rigidbody
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Start ()
    {
        //Raffle target's start position
        leftStartPos = new Vector2(-3.7f, Random.Range(-4.0f, 4.0f));
        rightStartPos = new Vector2(3.7f, Random.Range(-4.0f, 4.0f));

        //Set speed
        speed = 0.5f;

        //Raffle a random number between 0 and 1 and save it to variable n
        n = Random.Range(0.0f, 1.0f);

        //Set target's position
        if (n <= 0.5f)
        {
            transform.position = leftStartPos;
        }
        else if (n > 0.5f)
        {
            transform.position = rightStartPos;
        }

        //Set target's velocity
        rb.velocity = new Vector2(speed, 0);
	}

	void Update ()
    {
        //If target is too much left, set speed to right
		if(transform.position.x < -3.7)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        //If target is too much right, set speed to left
        else if(transform.position.x > 3.7)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        //Set target's speed to zero if bullet has missed it
        if(transform.position.y < -4.0f && transform.position.x == 0.0f)
        {
            rb.velocity = new Vector2(0, 0);
        }
        //Increase target's speed after hit
        if(transform.position.x < -3.75f || transform.position.x > 3.75f)
        {
            speed = speed + 0.1f;
        }
    }

    public void TargetPosAfterRestart()
    {
        //Create vectors to set target's positions after hit
        leftRePos = new Vector2(-3.7f, Random.Range(-4.0f, 4.0f));
        rightRePos = new Vector2(3.7f, Random.Range(-4.0f, 4.0f));

        //Raffle a random number between 0 and 1 and save it to variable n
        n = Random.Range(0.0f, 1.0f);

        //Set target's position
        if (n <= 0.5f)
        {
            transform.position = leftRePos;
        }
        else if (n > 0.5f)
        {
            transform.position = rightRePos;
        }
        //Set target's speed to the same as it was at start
        speed = 0.5f;
    }
}
