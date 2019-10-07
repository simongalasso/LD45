using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spikes : MonoBehaviour
{
    public GameObject hudCanvas;
    public GameObject Player;
    public GameObject Respawn;
    public bool isAnimated = false;
    public float time = 3;
    public float colorSpeed;

    private bool check = false;
    private AudioSource spikeSound;
    private ColorSwitcher colorSwitcher;
    private Color colorTmp;

    private void Start()
    {
        colorSwitcher = GetComponent<ColorSwitcher>();
        spikeSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isAnimated && check == false)
        {
            check = true;
            StartCoroutine(spikepop());
        }

        if (colorTmp.a > 0)
        {
            colorTmp.a -= 0.01f * Time.deltaTime * colorSpeed;
            hudCanvas.transform.GetChild(2).GetComponent<Image>().color = colorTmp;
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
            colorTmp = hudCanvas.transform.GetChild(2).GetComponent<Image>().color;
            colorTmp.a = 1f;
            hudCanvas.transform.GetChild(2).GetComponent<Image>().color = colorTmp;
            colorSwitcher.ChangeColor();
            spikeSound.PlayOneShot(spikeSound.clip);
            Player.transform.position = Respawn.transform.position;
        }
    }
}
