using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
  public GameObject Player;
  public GameObject DeathCanvas;
  private int timer = 21;
  private Rigidbody rb;

  void Start()
  {
        rb = Player.GetComponent<Rigidbody>();
        DeathCanvas.SetActive(false);
  }

  void Update()
  {
        if (timer < 20)
        {
            timer++;
            rb.velocity = Vector3.zero;
        }
        else
          DeathCanvas.SetActive(false);

  }

  public void respawnplayer()
  {
        DeathCanvas.SetActive(true);
        timer = 0;
        Player.transform.position = transform.position;
  }
}
