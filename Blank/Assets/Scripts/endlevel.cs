using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endlevel : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public CameraController cameraController;
    public GameObject Player;
    public float range = 10f;
    public bool end = false;

    private AudioSource victorySound;

    private void Start()
    {
        victorySound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collision)
    {
         if (collision.gameObject == Player)
         {
            victorySound.PlayOneShot(victorySound.clip);
            cameraController.ChangeCameraPosition();
            if (end == true)
                pauseMenu.End();
            else
                pauseMenu.Victory();
         }
    }
}
