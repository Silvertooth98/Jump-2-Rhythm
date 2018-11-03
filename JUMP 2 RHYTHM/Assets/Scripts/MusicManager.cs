using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip Level01Song;
    AudioSource Level01SongSource;

    void Awake()
    {
        Level01SongSource = gameObject.GetComponent<AudioSource>();
        Level01SongSource.clip = Level01Song;
        Level01SongSource.Play();
    }

    public void MusicRestart()
    {
        Level01SongSource.Stop();
        Level01SongSource.Play();
    }

    public void StopMusic()
    {
        Level01SongSource.Pause();
    }

    public void PlayMusic()
    {
        Level01SongSource.UnPause();
    }
}
