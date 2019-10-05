using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endlevel : MonoBehaviour
{

    public GameObject Player;

    void OnTriggerEnter(Collider collision)
    {
         if(collision.gameObject == Player)
         {
              // Pause Game, victory screen time ?
              SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
         }
    }
}
