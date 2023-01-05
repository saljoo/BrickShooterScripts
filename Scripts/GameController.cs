using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    //VARIABLES

    //Variable to set high score text
    public Text highScore;

    //Private variable to save player's current score
    private int playerScore;

    //Get DataController script
    private DataController dataController;

    //Get BulletMovement script
    private BulletMovement bulletMovement;

    //CODE STARTS HERE

	void Start ()
    {
        //Find DataController and BulletMovement scripts
        dataController = FindObjectOfType<DataController>();
        bulletMovement = FindObjectOfType<BulletMovement>();

        //Set player's score to same as points in BulletMovement script
        playerScore = bulletMovement.points;
	}

	void Update ()
    {
        //Set player's score to same as points in BulletMovement script
        playerScore = bulletMovement.points;

        //Submit player's score
        dataController.SubmitNewPlayerScore(playerScore);

        //Show highest score
        highScore.text = "High score: " + dataController.GetHighestPlayerScore().ToString();
	}
}
