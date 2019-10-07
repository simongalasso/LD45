using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public GameObject Player;

    void OnTriggerEnter(Collider collision)
    {
        GameObject go = GameObject.Find("Respawn");
        respawn other = (respawn) go.GetComponent(typeof(respawn));
        if(collision.gameObject == Player)
        {
           other.respawnplayer();
        }
    }
}
