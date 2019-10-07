using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitcher : MonoBehaviour
{
    public Material materialOn;
    public Material materialOff;

    private bool state = false;

    public void ChangeColor()
    {
        if (state == false)
            transform.GetChild(0).GetComponent<Renderer>().material = materialOn;
        state = !state;
    }
}
