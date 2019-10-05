using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootMarker : MonoBehaviour
{
    public GameObject footMarker;
    public GameObject footPosition;
    public float distanceBetweenFootPrint;
    public float groundCheck;

    private Vector2 lastPos;

    private void Start()
    {
        lastPos = transform.position;
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        Debug.DrawRay(footPosition.transform.position, -footPosition.transform.up * groundCheck, Color.red);

        if (Vector2.Distance(transform.position, lastPos) > distanceBetweenFootPrint)
        {
            if (Physics.Raycast(footPosition.transform.position, -footPosition.transform.up, out hit, groundCheck))
            {
                GameObject newDecal = Instantiate(footMarker, hit.point, Quaternion.LookRotation(Vector3.up, hit.normal));
                newDecal.transform.position -= newDecal.transform.forward * 0.1f;
                lastPos = transform.position;
            }
        }
    }
}
