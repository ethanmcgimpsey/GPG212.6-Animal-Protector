using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    public Transform cam; // Reference to the camera Transform

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to the center of the screen
    }

    private void Update()
    {
        // Player Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;
        camForward.y = 0f; // Remove the y component to make movement horizontal
        camRight.y = 0f;

        Vector3 moveDirection = camForward.normalized * vertical + camRight.normalized * horizontal;
        moveDirection.y = 0f; // Prevent movement in the y-axis (up and down)

        if (moveDirection != Vector3.zero)
        {
            // Rotate the player to face the movement direction
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        // Move the player
        rb.MovePosition(transform.position + moveDirection.normalized * moveSpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        // Camera Control
        // Assuming the camera is a child of the player object and positioned correctly
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the player horizontally based on mouse movement
        transform.Rotate(Vector3.up * mouseX * rotationSpeed);

        // Rotate the camera vertically based on mouse movement
        Vector3 camEuler = cam.rotation.eulerAngles;
        camEuler.x -= mouseY * rotationSpeed;

        // Limit the camera's vertical rotation (optional)
        camEuler.x = Mathf.Clamp(camEuler.x, -80f, 80f);

        cam.rotation = Quaternion.Euler(camEuler);
    }
}