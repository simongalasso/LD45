using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public GameObject Player;
    public GameObject Respawn;
    public bool isAnimated = false;
    public float time = 3;

    private bool check = false;
    private AudioSource spikeSound;

    private void Start()
    {
        spikeSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isAnimated && check == false)
        {
            check = true;
            StartCoroutine(spikepop());
        }
    }

    public IEnumerator spikepop()
    {
        yield return new WaitForSeconds(time);
        transform.position = transform.position + transform.up * -10;
        yield return new WaitForSeconds(time);
        transform.position = transform.position + transform.up * 10;
        check = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == Player)
        {
            //Red screen
            spikeSound.PlayOneShot(spikeSound.clip);
            Player.transform.position = Respawn.transform.position;
        }
    }
}
