using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public float speed;
    public float lookSensitivity;
    public float smoothing;
    public GameObject ladderCheckPos;
    public float ladderCheckDist;
    public LayerMask ladderMask;
    public float climbSpeed;

    private Rigidbody rb;
    private Vector2 smoothedVelocity;
    private Vector2 currentLookingPos;
    private float x = 0;
    private float y = 0;
    private float z = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        // CALC PLAYER MOVEMENT
        x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        y = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        // CALC CLIMB LADDERS
        //Debug.DrawRay(ladderCheckPos.transform.position, ladderCheckPos.transform.forward * ladderCheckDist, Color.red);
        if (y > 0 && Physics.Raycast(ladderCheckPos.transform.position, ladderCheckPos.transform.forward, ladderCheckDist, ladderMask))
        {
            rb.useGravity = false;
            z = y;
        }
        else if (rb.useGravity == false)
        {
            rb.useGravity = true;
            z = 0;
        }

        // APPLY MOVEMENTS
        rb.MovePosition(transform.position + (transform.right * x) + (transform.forward * y) + (transform.up * z));
    }

    private void Update()
    {
        // PLAYER ROTATION
        if (!pauseMenu.gamePaused)
        {
            Vector2 inputValues = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            inputValues = Vector2.Scale(inputValues, new Vector2(lookSensitivity * smoothing, lookSensitivity * smoothing));

            smoothedVelocity.x = Mathf.Lerp(smoothedVelocity.x, inputValues.x, 1f / smoothing);
            smoothedVelocity.y = Mathf.Lerp(smoothedVelocity.y, inputValues.y, 1f / smoothing);

            currentLookingPos += smoothedVelocity;

            transform.GetChild(0).transform.localRotation = Quaternion.AngleAxis(-currentLookingPos.y, Vector3.right);
            transform.localRotation = Quaternion.AngleAxis(currentLookingPos.x, Vector3.up);
        }
    }
}
