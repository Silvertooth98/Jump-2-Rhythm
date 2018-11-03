using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialKillPlatforms : MonoBehaviour
{
    public GameObject MovingCrabCanvas;
    public GameObject KillPlatformCanvas;

    public PauseGame pauseScript;

    void Start()
    {
        pauseScript = FindObjectOfType<PauseGame>();
    }

    public void OnTriggerEnter(Collider other)
    {
        pauseScript.Pause(); //Pause the game
        MovingCrabCanvas.SetActive(false); //Remove the tutorial canvas about the moving obstacles
        KillPlatformCanvas.SetActive(true); //Display the tutorial canvas about the kill platforms
    }
}
