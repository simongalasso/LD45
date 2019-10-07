using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endlevel : MonoBehaviour
{

    public GameObject Player;
    public float range = 10f;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    void Update()
    {
        if(Vector3.Distance(Player.transform.position, transform.position) <= range)
        {
          rend.enabled = true;
        }
        else
        {
          rend.enabled = false;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
         if(collision.gameObject == Player)
         {
              // Pause Game, victory screen time ?
              SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
         }
    }
}
