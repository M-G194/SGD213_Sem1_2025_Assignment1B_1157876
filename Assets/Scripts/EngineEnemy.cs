using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineEnemy : EngineBase
{
    private Vector2 movementDirection;

    
    private WeaponBase weapon;
    
    

    void Start()
    {
        weapon = GetComponent<WeaponBase>();
        ourRigidbody = GetComponent<Rigidbody2D>();

        // get a random direction between South-East and South-West
        float x = Random.Range(-0.5f, 0.5f);
        float y = -0.5f;
        movementDirection = new Vector2(x, y).normalized; // ensure it is normalised
        
        // move our enemy
        updateVelocity(movementDirection);
    }

    // Update is called once per frame
    void Update () {
        // shoot if we have a IWeapon component attached
        if (weapon != null) {
            weapon.Shoot();
        }
    }
}
