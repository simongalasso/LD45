using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endlevel : MonoBehaviour
{

    public GameObject Player;
    public float range = 10f;
    private Renderer rend;
    public static float timer;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(Vector3.Distance(Player.transform.position, transform.position) <= range)
        {
          rend.enabled = true;
        }
        else
        {
          rend.enabled = false;
        }
    }

    void  OnGUI()
    {
      if (rend.enabled == true)
      {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        GUI.Label(new Rect(10, 10, 200, 100), niceTime);
      }
    }

    void OnTriggerEnter(Collider collision)
    {
         if(collision.gameObject == Player)
         {
              SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
              timer = 0;
         }
    }
}
