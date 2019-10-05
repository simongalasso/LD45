using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootMarker : MonoBehaviour
{
    public GameObject footMarker;
    public GameObject footPosition;
    public float distanceBetweenFootPrint;
    public float groundCheck;
    public float footPrintShift;

    private Vector3 lastPos;
    private int leftFoot = 1;

    private void Start()
    {
        lastPos = transform.position;
    }

    private void Update()
    {
        RaycastHit hit;

        Debug.DrawRay(footPosition.transform.position, -footPosition.transform.up * groundCheck, Color.red);

        if (Vector3.Distance(transform.position, lastPos) > distanceBetweenFootPrint)                                                                                                                                                                                                                                                                                                                                                                                 
        {
            if (Physics.Raycast(footPosition.transform.position, -footPosition.transform.up, out hit, groundCheck))
            {
                leftFoot = -leftFoot;
                GameObject newDecal = Instantiate(footMarker, new Vector3(hit.point.x, hit.point.y - 0.1f, hit.point.z), Quaternion.LookRotation(Vector3.up, hit.normal));
                newDecal.transform.Translate(transform.up * footPrintShift * leftFoot);
                lastPos = transform.position;
            }
        }
    }
}
