using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float rotationSpeed = 3.0f;
    public float acceleration = 5.0f;
    public float maxSpeed = 10.0f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10.0f;
    public float fireRate = 0.5f;
    private float nextFireTime;

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
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -cameraWidth, cameraWidth);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -cameraHeight, cameraHeight);
        transform.position = clampedPosition;

        // Shooting
        if (Time.time > nextFireTime && Input.GetMouseButtonDown(0))
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the spaceship to the mouse click
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Create a new bullet at the spaceship's position and rotation
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Set the bullet's velocity in the direction of the mouse click
        newBullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

}
