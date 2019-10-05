using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float lookSensitivity;
    public float smoothing;

    private Vector2 smoothedVelocity;
    private Vector2 currentLookingPos;
    private bool isCrouched = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // PLAYER MOVEMENT
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(x, 0, z);

        // PLAYER ROTATION
        Vector2 inputValues = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        inputValues = Vector2.Scale(inputValues, new Vector2(lookSensitivity * smoothing, lookSensitivity * smoothing));

        smoothedVelocity.x = Mathf.Lerp(smoothedVelocity.x, inputValues.x, 1f / smoothing);
        smoothedVelocity.y = Mathf.Lerp(smoothedVelocity.y, inputValues.y, 1f / smoothing);

        currentLookingPos += smoothedVelocity;

        transform.GetChild(0).transform.localRotation = Quaternion.AngleAxis(-currentLookingPos.y, Vector3.right);
        transform.localRotation = Quaternion.AngleAxis(currentLookingPos.x, Vector3.up);

        // CROUCH
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (!isCrouched)
                transform.GetChild(0).transform.localPosition = new Vector3(0, 0, 0);
            else
                transform.GetChild(0).transform.localPosition = new Vector3(0, 1.6f, 0);
            isCrouched = !isCrouched;
        }
    }
}
