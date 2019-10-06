using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootMarker : MonoBehaviour
{
    public GameObject footLMarker;
    public GameObject footRMarker;
    public GameObject footPosition;
    public float distanceBetweenFootPrint;
    public float groundCheck;
    public float footPrintShift;
    
    private GameObject footMarker;
    private AudioSource footSound;
    private Vector3 lastPos;
    private int leftFoot = 1;

    private void Start()
    {
        footMarker = footLMarker;
        footSound = GetComponent<AudioSource>();
        lastPos = transform.position;
    }

    private void Update()
    {
        RaycastHit hit;

        //Debug.DrawRay(footPosition.transform.position, -footPosition.transform.up * groundCheck, Color.red);

        if (Vector3.Distance(transform.position, lastPos) > distanceBetweenFootPrint)                                                                                                                                                                                                                                                                                                                                                                                 
        {
            if (Physics.Raycast(footPosition.transform.position, -footPosition.transform.up, out hit, groundCheck))
            {
                footSound.PlayOneShot(footSound.clip);
                if (leftFoot == 1)
                    footMarker = footLMarker;
                else
                    footMarker = footRMarker;
                leftFoot = -leftFoot;
                GameObject newDecal = Instantiate(footMarker, new Vector3(hit.point.x, footPosition.transform.position.y + 0.1f, hit.point.z), Quaternion.LookRotation(-Vector3.up, hit.normal));
                newDecal.transform.eulerAngles = new Vector3(newDecal.transform.eulerAngles.x, transform.eulerAngles.y, newDecal.transform.eulerAngles.z);
                newDecal.transform.position += transform.TransformDirection(Vector3.right * leftFoot) * footPrintShift;
                lastPos = transform.position;
            }
        }
    }
}
