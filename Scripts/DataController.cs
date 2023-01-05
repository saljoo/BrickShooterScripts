using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour {

    //VARIABLES

    //Get PlayerProgress script
    private PlayerProgress playerProgress;

    //CODE STARTS HERE

    void Start()
    {
        //Load player's progress att start
        LoadPlayerProgress();
    }

    public void SubmitNewPlayerScore(int newScore)
    {
        //Set new high score if player's points are bigger than current high score
        if(newScore > playerProgress.highestScore)
        {
            playerProgress.highestScore = newScore;

            //Save new high score
            SavePlayerProgress();
        }
    }

    public int GetHighestPlayerScore()
    {
        //Return player's highest score
        return playerProgress.highestScore;
    }

    private void LoadPlayerProgress()
    {
        //Set player's progress
        playerProgress = new PlayerProgress();

        if (PlayerPrefs.HasKey("highestScore"))
        {
            //Get highest score
            playerProgress.highestScore = PlayerPrefs.GetInt("highestScore");
        }
    }

    private void SavePlayerProgress()
    {
        //Save highest score
        PlayerPrefs.SetInt("highestScore", playerProgress.highestScore);
    }
}
