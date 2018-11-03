using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUmbrellaTriggerBox : MonoBehaviour
{
    public GameObject CrabCanvas;
    public GameObject UmbrellaCanvas;

    public PauseGame pauseScript;

    void Start()
    {
        pauseScript = FindObjectOfType<PauseGame>();
    }

    public void OnTriggerEnter(Collider other)
    {
        pauseScript.Pause(); //Pause the game
        CrabCanvas.SetActive(false); //Remove the tutorial canvas about the obstacles
        UmbrellaCanvas.SetActive(true); //Display the tutorial canvas about the platforms
    }
}
