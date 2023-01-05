using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletMovement : MonoBehaviour {

    //VARIABLES

    //Variable speed for bullet
    private float speed;

    private Rigidbody rb;

    //Transform target
    public Transform target;

    //Variable to save bullet's original position
    private Vector2 originalPos;

    //Variable to save target's position after miss
    private Vector2 missPos;

    //Variables to set target's position after hit
    private Vector2 leftPos;
    private Vector2 rightPos;

    //Variable to save random numbers between 0 and 1
    private float n;

    //Variable to set points
    public int points;

    //Public variable to show points
    public Text pointsText;

    //Gameobject to set restart menu active
    public GameObject restartMenu;

    //Variable to check if bullet can be shooted
    private bool bulletCanShoot;

    //CODE STARTS HERE

	void Start ()
    {
        //Set bullet's speed
        speed = 6.0f;

        //Create rigidbody
        rb = gameObject.GetComponent<Rigidbody>();

        //Save bullet's original position
        originalPos = gameObject.transform.position;

        //Set target's miss position
        missPos = new Vector2(0, -4.3f);

        //Set points to zero at start
        points = 0;

        //Show points
        SetPoints();

        //Bullet can be shooted at start
        bulletCanShoot = true;
    }
	
	void Update ()
    {
        //Check is restart menu active
        if (restartMenu.activeSelf == true)
        {
            //Bullet can't be shooted after miss
            bulletCanShoot = false;
        }
        else if (restartMenu.activeSelf == false)
        {
            //Bullet can be shooted after restart
            bulletCanShoot = true;
        }

        //Check can bullet be shooted
        if (bulletCanShoot == true)
        {
            //Shoot bullet if screen is clicked
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector2(0, speed);
            }
        }
        
        //Create vectors to set target's positions after hit
        leftPos = new Vector2(-3.8f, Random.Range(-4.0f, 4.0f));
        rightPos = new Vector2(3.8f, Random.Range(-4.0f, 4.0f));

        //Raffle a random number between 0 and 1 and save it to variable n
        n = Random.Range(0.0f, 1.0f);

        //Check if bullet has missed target
        if (transform.position.y-target.position.y > 1.0f)
        {
            //Set bullet to its original position
            transform.position = originalPos;
            //Set bullet's speed to zero
            rb.velocity = new Vector2(0, 0);
            //Set target to its miss position
            target.position = missPos;
            //Set restart menu active
            restartMenu.SetActive(true);
            //Set points to zero
            points = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //If bullet hits the target, set bullet to its original position
        //and set its velocity to zero.
        //Set target to its left position or right position
        if (other.gameObject.CompareTag("Target"))
        {
            //Set target's position
            if (n <= 0.5f)
            {
              target.position = leftPos;
            }
            else if (n > 0.5f)
            {
              target.position = rightPos;
            }

            //Set bullet to its original position
            transform.position = originalPos;
            //Set bullet's speed to zero
            rb.velocity = new Vector2(0, 0);

            //Increase points
            points = points + 1;
            //Show points
            SetPoints();
        }
    }

    public void SetPoints()
    {
        //Show points
        pointsText.text = "Points: " + points.ToString();
    }
}
