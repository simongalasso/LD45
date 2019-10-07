using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    public GameObject Player;
    public GameObject Respawn;

    void OnTriggerEnter(Collider collision)
    {
         if(collision.gameObject == Player)
         {
           //Red screen
           //Delay
           Player.transform.position = Respawn.transform.position;
         }
    }
}
