using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [Tooltip("The speed at which the unit moves")]
    [SerializeField] float Speed;

    [Header("References")]
    [SerializeField] GameObject HandRef;

    /// <summary>
    /// Stores a reference to the current weapon that the unit is holding
    /// </summary>
    [SerializeField] Weapon currentWeapon;

    /// <summary>
    /// Is the unit currently aiming with the weapon
    /// </summary>
    bool isAiming;

    private void Start()
    {
        Pickup(currentWeapon);
        StopAiming();
    }

    /// <summary>
    /// Move the unit in the given direction based on unit's speed
    /// </summary>
    /// <param name="direction">The direction in which the unit must move</param>
    public void Move(Vector2 direction)
    {
        direction = direction.normalized;
        transform.position += (Vector3) direction * Speed * Time.deltaTime;
    }

    public void LookAt(Vector3 position)
    {
        // get the look at direction from the position
        Vector3 dir = position - transform.position;
        dir = dir.normalized;

        // make the character look at the given direction
        transform.up = dir;
    }

    public void FireWeapon()
    {
        if(!isAiming) { return; }

        currentWeapon.Fire();
    }

    public void StartAiming()
    {
        isAiming = true;
        HandRef.SetActive(true);
    }

    public void StopAiming()
    {
        isAiming = false;
        HandRef.SetActive(false);
    }

    public void Pickup(Weapon weapon)
    {
        // no weapon was given, and can't pick it up
        if(weapon == null) 
        { 
            return; 
        }

        if(weapon.RequestPickup(this))
        {
            currentWeapon = weapon;
        }
    }
}
