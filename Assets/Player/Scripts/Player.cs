using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float rotationSpeed = 3.0f;
    public float acceleration = 5.0f;
    public float maxSpeed = 10.0f;

    private Camera mainCamera;
    private float cameraWidth;
    private float cameraHeight;

    private void Start()
    {
        mainCamera = Camera.main;
        cameraHeight = mainCamera.orthographicSize;
        cameraWidth = cameraHeight * mainCamera.aspect;
    }

    private void Update()
    {
        // Rotation input
        float rotationInput = Input.GetAxis("Horizontal");
        // Forward and backward input
        float moveInput = Input.GetAxis("Vertical");

        // Rotate the spaceship
        float rotation = rotationInput * rotationSpeed;
        transform.Rotate(0, 0, -rotation);

        // Apply forward or backward movement
        float moveSpeed = moveInput * acceleration;
        Vector3 moveDirection = transform.up * moveSpeed;
        transform.Translate(moveDirection * Time.deltaTime, Space.World);

        // Clamp the spaceship's position within camera bounds
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -cameraWidth + 0.5f, cameraWidth - 0.5f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -cameraHeight + 0.5f, cameraHeight - 0.5f);
        transform.position = clampedPosition;

        // Limit the speed of the spaceship
        if (moveDirection.magnitude > maxSpeed)
        {
            moveDirection = moveDirection.normalized * maxSpeed;
        }
    }
}
