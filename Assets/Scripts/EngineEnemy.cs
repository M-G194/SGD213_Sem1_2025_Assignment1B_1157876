using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineEnemy : EngineBase
{
    private WeaponBase weapon;

    // The direction in which the enemy moves when it spawns
    private Vector2 initialMovement;

    // How fast the enemy moves when it spawns
    public float initialMovementSpeed = 1.0f;

    void Start()
    {
        weapon = GetComponent<WeaponBase>();
        ourRigidbody = GetComponent<Rigidbody2D>();

        // Get a random direction between South-East and South-West
        float x = Random.Range(-0.5f, 0.5f);
        float y = -0.5f;
        // Ensure it is normalised
        initialMovement = new Vector2(x, y).normalized;
        // Adjust the movement speed
        initialMovement *= initialMovementSpeed;
        
        // Move our enemy
        updateVelocity(initialMovement);
    }

    // Update is called once per frame
    void Update () {
        // Shoot if we have a weapon component attached
        if (weapon != null) {
            weapon.Shoot();
        }
    }
}
