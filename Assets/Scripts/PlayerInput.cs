using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlayerInput handles all of the player specific input behaviour, and passes the input information
/// to the appropriate scripts.
/// </summary>
public class PlayerInput : MonoBehaviour
{
    private EngineBase engineBase;
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


    void Start()
    {
        engineBase = GetComponent<EngineBase>();
        weapon = GetComponent<WeaponBase>();
    }

    void Update()
    {
        // Movement
        float HorizontalInput = Input.GetAxis("Horizontal");

        if (HorizontalInput != 0.0f)
        {
            // Check if the moving script component is applied
            if (engineBase != null)
            {
                // Turn the player input (-1.0 to 1.0) into a Vector2 direction
                var direction = new Vector2(HorizontalInput, 0f);
                // Then move with that force value
                engineBase.Accelerate(direction);
            }
            else
            {
                Debug.Log("Movement script not found!");
            }
        }

        // Shooting
        if (Input.GetButton("Fire1"))
        {
            if (weapon != null)
            {
                weapon.Shoot();
            }
            else
            {
                Debug.Log("Weapon script not found!");
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
        // Make a new weapon dependent on the weaponType
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

        // Update the data of our newWeapon with that of our current weapon
        newWeapon.UpdateWeaponControls(weapon);
        // Remove the old weapon
        Destroy(weapon);
        // Set our current weapon to be the newWeapon
        weapon = newWeapon;
    }
}
