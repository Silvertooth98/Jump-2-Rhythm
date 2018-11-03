using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMovingCrabs : MonoBehaviour
{
    public GameObject UmbrellaCanvas;
    public GameObject MovingCrabCanvas;

    public PauseGame pauseScript;

    void Start()
    {
        pauseScript = FindObjectOfType<PauseGame>();
    }

    public void OnTriggerEnter(Collider other)
    {
        pauseScript.Pause(); //Pause the game
        UmbrellaCanvas.SetActive(false); //Remove the tutorial canvas about the platforms
        MovingCrabCanvas.SetActive(true); //Display the tutorial canvas about the moving obstacles
    }
}
