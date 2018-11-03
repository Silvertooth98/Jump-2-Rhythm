using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TutorialWin : MonoBehaviour
{
    public GameObject TestItOutText;
    public GameObject WinCanvas;

    public void ReplayTutorial()
    {
        Debug.Log("Replay Tutorial");
        SceneManager.LoadScene("Tutorial");
    }

    public void PlayLevel01()
    {
        Debug.Log("Play Level 1");
        SceneManager.LoadScene("Level01");
    }

    public void MainMenu()
    {
        Debug.Log("Exit to Main Menu");
        SceneManager.LoadScene("MainMenu");
    }

    public void OnTriggerEnter(Collider other)
    {
        //Display the win canvas
        TestItOutText.SetActive(false);
        WinCanvas.SetActive(true);

        PauseGame.GameWin();
    }
}
