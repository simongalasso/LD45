using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
      public GameObject Player;
      public float time = 3;
      private bool check = false;

      public IEnumerator spikepop()
      {
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
          GameObject go = GameObject.Find("Respawn");
          respawn other = (respawn) go.GetComponent(typeof(respawn));
          if(collision.gameObject == Player)
          {
              other.respawnplayer();
          }
      }
}
