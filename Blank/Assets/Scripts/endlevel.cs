using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endlevel : MonoBehaviour
{
    public GameObject Player;
    public float range = 10f;

    void OnTriggerEnter(Collider collision)
    {
         if (collision.gameObject == Player)
         {
              SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         }
    }
}
