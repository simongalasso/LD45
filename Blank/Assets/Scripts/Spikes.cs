using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
      public GameObject Player;
      public GameObject Respawn;

      void OnTriggerEnter(Collider collision)
      {
           if(collision.gameObject == Player)
           {
                // Red screen, delay d'une seconde
                Player.transform.position = Respawn.transform.position;
           }
      }
}
