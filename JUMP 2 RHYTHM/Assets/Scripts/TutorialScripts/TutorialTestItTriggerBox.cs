using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTestItTriggerBox : MonoBehaviour
{
    public GameObject KillPlatformCanvas;
    public GameObject TestItOutText;

    public void OnTriggerEnter(Collider other)
    {
        KillPlatformCanvas.SetActive(false); //Remove the tutorial canvas about the platforms
        TestItOutText.SetActive(true); //Display the tutorial canvas about testing the game out
    }
}
