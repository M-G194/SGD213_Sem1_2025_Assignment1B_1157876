using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private PlayerMovementScript playerMovementScript;
    private ShootingScript shootingScript;

    void Start()
    {
        playerMovementScript = GetComponent<PlayerMovementScript>();
        shootingScript = GetComponent<ShootingScript>();
    }

    void Update()
    {
        // Movement
        float HorizontalInput = Input.GetAxis("Horizontal");

        if (HorizontalInput != 0.0f)
        {
            if (playerMovementScript != null)
            {
                playerMovementScript.HorizontalMovement(HorizontalInput);
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
