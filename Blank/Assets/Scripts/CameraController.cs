using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public Transform endCameraPos;
    public float speed;

    private bool shouldMove = false;

    public void ChangeCameraPosition()
    {
        pauseMenu.gamePaused = true;
        transform.parent = null;
        shouldMove = true;
    }

    private void Update()
    {
        if (shouldMove == true)
        {
            transform.position = Vector3.Lerp(transform.position, endCameraPos.position, speed * Time.deltaTime);

            Vector3 currentAngle = new Vector3(
            Mathf.LerpAngle(transform.rotation.eulerAngles.x, endCameraPos.rotation.eulerAngles.x, Time.deltaTime * speed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.y, endCameraPos.rotation.eulerAngles.y, Time.deltaTime * speed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.z, endCameraPos.rotation.eulerAngles.z, Time.deltaTime * speed));

            transform.eulerAngles = currentAngle;
        }
    }
}
