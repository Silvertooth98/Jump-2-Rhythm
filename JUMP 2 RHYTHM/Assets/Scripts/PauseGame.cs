using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private MusicManager Level01Song;

    Scene currentScene;
    string sceneName;

    public static bool isGamePaused = false;

    // Use this for initialization
    void Start ()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        Level01Song = (MusicManager)FindObjectOfType<MusicManager>();
        Time.timeScale = 1;
	}
	
    public void Pause()
    {
        isGamePaused = true;
        Time.timeScale = 0;

        if (sceneName == "Level01")
        {
            Level01Song.StopMusic();
        }
    }

    public static void GameWin()
    {
        isGamePaused = true;
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        isGamePaused = false;
        Time.timeScale = 1;

        if (sceneName == "Level01")
        {
            Level01Song.PlayMusic();
        }
    }

    public void MainMenu()
    {
        Debug.Log("Exit to Main Menu");
        SceneManager.LoadScene("MainMenu");
    }
}
