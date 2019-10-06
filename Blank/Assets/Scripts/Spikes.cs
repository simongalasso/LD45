using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
      public GameObject Player;
      public GameObject Respawn;
      public float time = 3;
      private bool check = false;

      public IEnumerator spikepop()
      {
          check = true;
          yield return new WaitForSeconds(time);
          transform.position = transform.position + transform.up * -10;
          yield return new WaitForSeconds(time);
          transform.position = transform.position + transform.up * 10;
          check = false;
      }


      void Update()
      {
          if (check == false)
          {
            check = true;
            StartCoroutine(spikepop());
          }
      }

      void OnTriggerEnter(Collider collision)
      {
           if(collision.gameObject == Player)
           {
                // Red screen, delay d'une seconde
                Player.transform.position = Respawn.transform.position;
           }
      }
}
