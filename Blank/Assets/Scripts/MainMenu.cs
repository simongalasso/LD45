using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource[] sounds;

    private void Start()
    {
        sounds = GetComponents<AudioSource>();
    }

    public void PlayGame()
    {
        sounds[1].PlayOneShot(sounds[1].clip);
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void playSound()
    {
        sounds[0].PlayOneShot(sounds[0].clip);
    }
}
