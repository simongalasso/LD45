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

    void OnTriggerEnter(Collider collision)
    {
         if (collision.gameObject == Player)
         {
            cameraController.ChangeCameraPosition();
            pauseMenu.Victory();
         }
    }
}
