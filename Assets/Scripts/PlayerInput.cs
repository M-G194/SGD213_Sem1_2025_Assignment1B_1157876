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
            if (movingScript != null)
            {
                var moveForce = new Vector2(HorizontalInput * moveSpeed, 0f);

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
