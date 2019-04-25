using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public Transform respawnPoint;
    public Transform teleportToStartPoint;
    public Transform teleportToNextPos1;
    public Transform teleportToNextPos2;
    public Transform teleportToNextPos3;

    bool isGrounded = true;
    bool isFalling = false;

    private float movementSpeed = 4.0f;
    private float jumpSpeed = 5.0f;
    private Rigidbody rb;
    private MusicManager Level01Song;

    public Text deathCounter;
    int totalDeaths;

    Text highScoreLevel01Text;
    int highScoreLevel01;
    Text highScoreLevel02Text;
    int highScoreLevel02;

    Scene currentScene;
    string sceneName;

    public GameObject TestText;
    public GameObject BallMovementText;

    public Image fadeImage;
    private bool isInTransition;
    private float transition;
    private bool b_isShowing;
    private bool b_hasDied;
    private bool b_teleportedToStart;
    private bool b_teleportedToNextPos;
    private float duration;

    public void Fade(bool showing, float duration)
    {
        b_isShowing = showing;
        isInTransition = true;
        this.duration = duration;
        transition = (b_isShowing) ? 0 : 1;
    }

    // Use this for initialization
    void Start ()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        highScoreLevel01 = PlayerPrefs.GetInt("HighscoreL1", highScoreLevel01);
        highScoreLevel02 = PlayerPrefs.GetInt("HighscoreL2", highScoreLevel02);
        Level01Song = (MusicManager)FindObjectOfType<MusicManager>();
        rb = GetComponent<Rigidbody>();
        PauseGame.isGamePaused = false;
        if (sceneName == "Tutorial")
        {
            TutorialRespawn();
        }
        else
        {
            Respawn();
        }
    }

    private void Update()
    {
        if (isInTransition && b_hasDied == true)
        {
            transition += (b_isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
            fadeImage.color = Color.Lerp(new Color(1, 0, 0, 0), Color.white, transition); //Red
        }
        else if (isInTransition && b_teleportedToStart == true)
        {
            transition += (b_isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
            fadeImage.color = Color.Lerp(new Color(0, 0, 1, 0), Color.white, transition); //Blue
        }
        else if (isInTransition && b_teleportedToNextPos == true)
        {
            transition += (b_isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
            fadeImage.color = Color.Lerp(new Color(1, 1, 0, 0), Color.white, transition); //Yellow
        }
        else if (transition > 1 || transition < 0)
        {
            isInTransition = false;
        }
    }

    void FixedUpdate()
    {        
        //check if the game is paused or not
        int i = PauseGame.isGamePaused ? 0 : 1;

        //player's automatic movement
        rb.velocity = new Vector3(movementSpeed * i, rb.velocity.y);

        if (rb.velocity.y < -0.1)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }

        //Check if they touch the screen, if they are on the ground and they are not falling
        //Meaning they cannot spam the jump button and you cannot jump even if you fall off the platform instead of jumping
        if (Input.touchCount > 0)
        {
            for (int j = 0; j < Input.touchCount; j++)
            {
                if (i == 1 && Input.GetTouch(0).phase == TouchPhase.Began | Input.GetTouch(0).phase == TouchPhase.Stationary && (isGrounded == true) && (isFalling == false))
                {
                    rb.velocity = new Vector3(rb.velocity.x, jumpSpeed);
                    isGrounded = false;
                }
            }
        }

        //Check if they press the jump key, if they are on the ground and they are not falling
        //Meaning they cannot spam the jump button and you cannot jump even if you fall off the platform instead of jumping
        if (i == 1 && Input.GetKey(KeyCode.Space) && (isGrounded == true) && (isFalling == false))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed);
            isGrounded = false;
        }

        deathCounter.text = "Total Deaths: " + totalDeaths.ToString(); //print the total deaths counter on the screen
    }

    void Respawn()
    {
        //move the player to the position of the respawn point
        //and restart the music using the MusicRestart function
        //within the MusicManager script
        Fade(false, 2.0f);
        transform.position = respawnPoint.transform.position;
        if (sceneName == "Level01")
        {
            Level01Song.MusicRestart();
        }
    }

    void TutorialRespawn()
    {
        Fade(false, 2.0f);
        TestText.SetActive(false);
        BallMovementText.SetActive(true);
        transform.position = respawnPoint.transform.position;
    }

    void Grounded()
    {
        isGrounded = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if the player collides with an enemy, clear the trail
        //add one to the total amount of deaths and then
        //respawn the player at the spawn point assigned
        if (collision.transform.tag == "Enemy")
        {
            b_teleportedToNextPos = false;
            b_teleportedToStart = false;
            b_hasDied = true;
            Fade(true, 1.25f);
            Debug.Log("Collision with: " + collision.transform.name);
            GetComponentInChildren<TrailRenderer>().Clear();
            totalDeaths++;

            if (sceneName == "Tutorial")
            {
                TutorialRespawn();
            }
            else
            {
                Respawn();
            }
        }

        //if the player lands on a platform, run the grounded function
        //which says the player is grounded allowing them to jump again
        else if (collision.transform.tag == "Platform")
        {
            Debug.Log("On the ground: " + collision.transform.name);
            Grounded();
        }

        //if the player collides with a blue umbrella (the teleporters to the start)
        //move the player back to the start, hence teleporting them back there
        else if (collision.transform.tag == "TeleporterStart")
        {
            Debug.Log("Teleported to start");
            b_teleportedToNextPos = false;
            b_hasDied = false;
            b_teleportedToStart = true;
            Fade(true, 1.25f);
            Fade(false, 2.0f);
            GetComponentInChildren<TrailRenderer>().Clear();
            transform.position = teleportToStartPoint.transform.position;
        }

        //if the player collides with a yellow umbrella (the teleporters to the next position)
        //move the player to the next position in the level, continuing the level
        else if (collision.transform.tag == "TeleporterNextPos1")
        {
            Debug.Log("Teleported to next pos");
            b_hasDied = false;
            b_teleportedToStart = false;
            b_teleportedToNextPos = true;
            Fade(true, 1.25f);
            Fade(false, 2.0f);
            GetComponentInChildren<TrailRenderer>().Clear();
            transform.position = teleportToNextPos1.transform.position;
        }

        //if the player collides with a yellow umbrella (the teleporters to the next position)
        //move the player to the next position in the level, continuing the level
        else if (collision.transform.tag == "TeleporterNextPos2")
        {
            Debug.Log("Teleported to next pos 2");
            b_hasDied = false;
            b_teleportedToStart = false;
            b_teleportedToNextPos = true;
            Fade(true, 1.25f);
            Fade(false, 2.0f);
            GetComponentInChildren<TrailRenderer>().Clear();
            transform.position = teleportToNextPos2.transform.position;
        }

        //if the player collides with a yellow umbrella (the teleporters to the next position)
        //move the player to the next position in the level, continuing the level
        else if (collision.transform.tag == "TeleporterNextPos3")
        {
            Debug.Log("Teleported to next pos 3");
            b_hasDied = false;
            b_teleportedToStart = false;
            b_teleportedToNextPos = true;
            Fade(true, 1.25f);
            Fade(false, 2.0f);
            GetComponentInChildren<TrailRenderer>().Clear();
            transform.position = teleportToNextPos3.transform.position;
        }
    }

    public void SetLevel01HighScore()
    {
        if (!PlayerPrefs.HasKey("HighscoreL1"))
        {
            highScoreLevel01 = totalDeaths;
            PlayerPrefs.SetInt("HighscoreL1", highScoreLevel01);
            PlayerPrefs.Save();
        }
        else
        {
            if (totalDeaths < highScoreLevel01)
            {
                highScoreLevel01 = totalDeaths;
                PlayerPrefs.SetInt("HighscoreL1", highScoreLevel01);
                PlayerPrefs.Save();
            }
        }
    }

    public void SetLevel02Highscore()
    {
        if (!PlayerPrefs.HasKey("HighscoreL2"))
        {
            highScoreLevel02 = totalDeaths;
            PlayerPrefs.SetInt("HighscoreL2", highScoreLevel02);
            PlayerPrefs.Save();
        }
        else
        {
            if (totalDeaths < highScoreLevel02)
            {
                highScoreLevel02 = totalDeaths;
                PlayerPrefs.SetInt("HighscoreL2", highScoreLevel02);
                PlayerPrefs.Save();
            }
        }
    }
}
