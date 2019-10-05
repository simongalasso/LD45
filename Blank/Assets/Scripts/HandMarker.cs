using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMarker : MonoBehaviour
{
    public GameObject handMark;

    private void Update()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.GetChild(0).GetChild(1).position, transform.GetChild(0).GetChild(1).forward * 10, Color.red);

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.GetChild(0).GetChild(1).position, transform.GetChild(0).GetChild(1).forward, out hit, 10))
        {
            GameObject newDecal = Instantiate(handMark, hit.point, Quaternion.LookRotation(Vector3.up, hit.normal));
            newDecal.transform.position -= newDecal.transform.forward * 0.1f;
        }
    }
}
