using System.Collections;
using System.Collections.Generic;
using UnityEditor.Sprites;
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
    [field: SerializeField] public Weapon currentWeapon { get; protected set; }

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
        ChangeSpriteActive(HandRef.GetComponent<SpriteRenderer>(), true);
        //HandRef.SetActive(true);
    }

    public void StopAiming()
    {
        isAiming = false;
        ChangeSpriteActive(HandRef.GetComponent<SpriteRenderer>(), false);
        //HandRef.SetActive(false);
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

    void ChangeSpriteActive(SpriteRenderer sprite, bool isActive)
    {
        // ignore if null or an invalid object is passed
        if(sprite == null) { return; }

        // set the active state
        sprite.enabled = isActive;

        // set the active state on all children, recursively
        var children = sprite.GetComponentsInChildren<SpriteRenderer>(includeInactive: true);
        foreach(var child in children)
        {
            child.enabled = isActive;
            //ChangeSpriteActive(child, isActive);
        }
    }
}
