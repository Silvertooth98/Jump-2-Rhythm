using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void PlayLevel01()
    {
        Debug.Log("Load Level 1");
        SceneManager.LoadScene("Level01");
    }

    public void PlayLevel02()
    {
        Debug.Log("Load Level 2");
        SceneManager.LoadScene("Level02Prototype");
    }

    public void PlayTutorial()
    {
        Debug.Log("Load Tutorial");
        SceneManager.LoadScene("Tutorial");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
