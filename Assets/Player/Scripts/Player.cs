using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float rotationSpeed = 3.0f;
    public float acceleration = 5.0f;
    public float maxSpeed = 10.0f;

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

        // Limit the speed of the spaceship
        if (moveDirection.magnitude > maxSpeed)
        {
            moveDirection = moveDirection.normalized * maxSpeed;
        }
    }
}
