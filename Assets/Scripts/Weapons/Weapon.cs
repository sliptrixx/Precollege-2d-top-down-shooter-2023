using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject ProjectilePrefab;

    Unit CurrentHolder = null;

    public void Fire()
    {
        var spawnedProjectile = Instantiate(ProjectilePrefab);
        spawnedProjectile.transform.position = transform.position;
        spawnedProjectile.transform.up = transform.up;

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
