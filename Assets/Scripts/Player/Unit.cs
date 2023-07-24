using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [Tooltip("The speed at which the unit moves")]
    [SerializeField] float Speed;

    [SerializeField] GameObject ProjectilePrefab;

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
        var spawnedProjectile = Instantiate(ProjectilePrefab);
        spawnedProjectile.transform.position = transform.position;
        spawnedProjectile.transform.up = transform.up;

        // get the projectile component and set this unit as the one who spawned the projectile
        var projectileComponent = spawnedProjectile.GetComponent<Projectile>();
        if(projectileComponent != null)
        {
            projectileComponent.SpawnedBy = this;
        }
    }
}
