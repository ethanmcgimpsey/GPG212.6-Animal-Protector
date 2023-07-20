using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 3f;
    public float impactForce = 10f;

    void Start()
    {
        // Destroy the projectile after a certain lifetime to prevent clutter
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move the projectile forward based on its speed
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the projectile collided with another GameObject
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Destroy the target GameObject
            Destroy(other.gameObject);

            // Destroy the projectile as well
            Destroy(gameObject);

            // Optionally, apply an impact force to the target GameObject
            Rigidbody targetRigidbody = other.gameObject.GetComponent<Rigidbody>();
            if (targetRigidbody != null)
            {
                targetRigidbody.AddForce(transform.forward * impactForce, ForceMode.Impulse);
            }
        }
    }
}
