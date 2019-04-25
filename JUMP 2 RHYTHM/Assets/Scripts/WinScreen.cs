using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public GameObject WinCanvas;

    public BallManager BM;

    Scene currentScene;
    string sceneName;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    public void PlayLevel02()
    {
        Debug.Log("Load Level 02");
        SceneManager.LoadScene("Level02Prototype");
    }

    public void PlayLevel01()
    {
        Debug.Log("Replay Level 1");
        SceneManager.LoadScene("Level01");
    }

    public void MainMenu()
    {
        Debug.Log("Exit to Main Menu");
        SceneManager.LoadScene("MainMenu");
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("You win");

        if (sceneName == "Level01")
        {
            Debug.Log("Set L1 HS");
            BM.SetLevel01HighScore();
        }

        else if (sceneName == "Level02Prototype")
        {
            Debug.Log("Set L2 HS");
            BM.SetLevel02Highscore();
        }

        //Display the win canvas
        WinCanvas.SetActive(true);

        PauseGame.GameWin();
    }
}
