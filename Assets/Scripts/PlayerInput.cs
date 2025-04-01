using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private MovingScript movingScript;
    private ShootingScript shootingScript;

    [SerializeField]
    private float moveSpeed = 5000f;

    void Start()
    {
        movingScript = GetComponent<MovingScript>();
        shootingScript = GetComponent<ShootingScript>();
    }

    void Update()
    {
        // Movement
        float HorizontalInput = Input.GetAxis("Horizontal");

        if (HorizontalInput != 0.0f)
        {
            // Check if the moving script component is applied
            if (movingScript != null)
            {
                // Combine the player input (-1.0 to 1.0) with the move speed
                var moveForce = new Vector2(HorizontalInput * moveSpeed, 0f);
                // Then move with that force value
                movingScript.Move(moveForce);
            }
            else
            {
                Debug.Log("Movement script not found!");
            }
        }

        // Shooting
        if (Input.GetButton("Fire1"))
        {
            if (shootingScript != null)
            {
                shootingScript.Shoot();
            }
            else
            {
                Debug.Log("Shooting script not found!");
            }
        }
    }
}
