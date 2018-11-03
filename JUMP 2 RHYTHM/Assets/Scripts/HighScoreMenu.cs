using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HighScoreMenu : MonoBehaviour
{
    public Text highScoreLevel01Text;
    int highScoreLevel01;
    public Text highScoreLevel02Text;
    int highScoreLevel02;

    void OnEnable()
    {
        //Fetch the PlayerPref settings
        SetL1Text();
        SetL2Text();
    }

    void SetL1Text()
    {
        if (PlayerPrefs.HasKey("HighscoreL1"))
        {
            highScoreLevel01 = PlayerPrefs.GetInt("HighscoreL1");
            highScoreLevel01Text.text = "Total Deaths: " + highScoreLevel01.ToString(); //print the highscore for the first level on the screen
        }
        else
        {
            highScoreLevel01Text.text = "No Scores Yet!";
        }
          
    }

    void SetL2Text()
    {
        if (PlayerPrefs.HasKey("HighscoreL2"))
        {
            highScoreLevel02 = PlayerPrefs.GetInt("HighscoreL2");
            highScoreLevel02Text.text = "Total Deaths: " + highScoreLevel02.ToString(); //print the highscore for the second level on the screen
        }
        else
        {
            highScoreLevel02Text.text = "No Scores Yet!";
        }
    }
}