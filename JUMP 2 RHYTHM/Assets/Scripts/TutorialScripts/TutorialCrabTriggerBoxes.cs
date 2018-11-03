using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCrabTriggerBoxes : MonoBehaviour
{
    public GameObject BallMovementText;
    public GameObject CrabCanvas;

    public PauseGame pauseScript;

    void Start()
    {
        pauseScript = FindObjectOfType<PauseGame>();
    }

    public void OnTriggerEnter(Collider other)
    {
        pauseScript.Pause(); //Pause the game
        BallMovementText.SetActive(false); //Remove the tutorial text about the movement
        CrabCanvas.SetActive(true); //Display the tutorial canvas about the obstacles
    }
}
