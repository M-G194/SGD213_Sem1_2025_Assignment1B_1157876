using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlayerInput handles all of the player specific input behaviour, and passes the input information
/// to the appropriate scripts.
/// </summary>
public class PlayerInput : MonoBehaviour
{

    private MovingScript movingScript;
    private ShootingScript shootingScript;
    private WeaponBase weapon;

    public WeaponBase Weapon
    {
        get
        {
            return weapon;
        }

        set
        {
            weapon = value;
        }
    }

    [SerializeField]
    private float moveSpeed = 5000f;

    void Start()
    {
        movingScript = GetComponent<MovingScript>();
        shootingScript = GetComponent<ShootingScript>();
        weapon = GetComponent<WeaponBase>();
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
    
    /// <summary>
    /// SwapWeapon handles creating a new WeaponBase component based on the given weaponType. This
    /// will popluate the newWeapon's controls and remove the existing weapon ready for usage.
    /// </summary>
    /// <param name="weaponType">The given weaponType to swap our current weapon to, this is an enum in WeaponBase.cs</param>
    public void SwapWeapon(WeaponType weaponType)
    {
        // make a new weapon dependent on the weaponType
        WeaponBase newWeapon = null;
        switch (weaponType)
        {
            case WeaponType.machineGun:
                newWeapon = gameObject.AddComponent<WeaponMachineGun>();
                break;
            case WeaponType.tripleShot:
                newWeapon = gameObject.AddComponent<WeaponTripleShot>();
                break;
        }

        // update the data of our newWeapon with that of our current weapon
        newWeapon.UpdateWeaponControls(weapon);
        // remove the old weapon
        Destroy(weapon);
        // set our current weapon to be the newWeapon
        weapon = newWeapon;
    }
}
