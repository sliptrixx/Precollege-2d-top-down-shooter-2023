using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [Header("Properties")]
    [Tooltip("The rate at which projectiles spawn. The projectiles will be " +
        "spawned once every x seconds specified")]
    [field: SerializeField] public float FireRate;

    [Header("References")]
    [SerializeField] protected GameObject ProjectilePrefab;

    [Header("Events")]
    [SerializeField] protected UnityEvent<Weapon> OnProjectileFired;

    // The current unit that holds the gun
    // it's a two way contract
    protected Unit CurrentHolder = null;

    // a timer that keeps track of time remaining to fire another projectile
    public float timeToFire { get; protected set; } = 0;

    private void Update()
    {
        timeToFire -= Time.deltaTime;
    }

    public void Fire()
    {
        // if the weapon isn't held by anyone, don't fire... illegal request
        if(CurrentHolder == null) { return; }

        // time hasn't elapsed yet relative to the fire rate
        if(timeToFire > 0) { return; }

        // handle what happens when the bullet is fired
        OnFire();

        // reset the time to fire, so units cannot spam bullet
        timeToFire = FireRate;

        // invoke an event to let people know that bullets have been fired
        OnProjectileFired.Invoke(this);
    }

    protected virtual void OnFire()
    {
        SpawnProjectile(0);
    }

    protected void SpawnProjectile(float deg)
    {
        // spawn the projectile and line it up relative to the weapon and the unit holding the weapon
        var spawnedProjectile = Instantiate(ProjectilePrefab);
        spawnedProjectile.transform.position = transform.position;

        spawnedProjectile.transform.up = Quaternion.AngleAxis(deg, Vector3.forward) * CurrentHolder.transform.up;

        // update who is firing the projectile
        var projectileComponent = spawnedProjectile.GetComponent<Projectile>();
        if (projectileComponent != null && CurrentHolder != null)
        {
            projectileComponent.SpawnedBy = CurrentHolder;
        }
    }

    public bool RequestPickup(Unit pickedUpBy)
    {
        // someone already has this weapon picked up
        if(CurrentHolder != null)
        {
            return false; // indicates the pickup has failed
        }

        CurrentHolder = pickedUpBy;
        return true; // indicates that the pickup was successful
    }
}
