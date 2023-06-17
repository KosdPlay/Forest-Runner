using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public AudioClip music;
    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.PlayOneShot(music);
    }


    public void Play()
    {
        SceneManager.LoadScene("LVL1");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
