using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    //Quit application
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    //Load game mode
    public void PlayGame()
    {
        SceneManager.LoadScene("GameMode");
    }

    //Load menu
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
