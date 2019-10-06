using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMarker : MonoBehaviour
{
    public GameObject handMark;
    public float touchDistance;

    private void Update()
    {
        RaycastHit hit;

        //Debug.DrawRay(transform.GetChild(0).GetChild(1).position, transform.GetChild(0).GetChild(1).forward * touchDistance, Color.red);

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.GetChild(0).GetChild(1).position, transform.GetChild(0).GetChild(1).forward, out hit, touchDistance))
        {
            GameObject newDecal = Instantiate(handMark, hit.point, transform.GetChild(0).rotation);
            newDecal.transform.position += newDecal.transform.TransformDirection(-Vector3.forward) * 0.5f;
        }
    }
}
