using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootingPoint;
    public float shootForce = 20f;
    public float cooldownDuration = .5f; // Adjust this value to set the cooldown duration (in seconds).

    private float cooldownTimer = 0f;

    void Update()
    {
        // Check if the cooldown timer has completed
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        // Detect when the player presses the fire button (e.g., Left Mouse Click) and cooldown is over
        if (Input.GetButtonDown("Fire1") && cooldownTimer <= 0f)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate the projectile prefab at the shooting point
        GameObject newProjectile = Instantiate(projectilePrefab, shootingPoint.position, shootingPoint.rotation);

        // Get the rigidbody of the projectile (assuming the prefab has one)
        Rigidbody projectileRigidbody = newProjectile.GetComponent<Rigidbody>();

        // Apply force to the projectile to make it move forward
        projectileRigidbody.AddForce(shootingPoint.forward * shootForce, ForceMode.Impulse);

        // Reset the cooldown timer
        cooldownTimer = cooldownDuration;
    }
}
