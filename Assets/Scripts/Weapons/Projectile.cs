using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float MaxRange;
    [SerializeField] int Damage;

    [HideInInspector] public Unit SpawnedBy;

    float distanceTravelled = 0;

    private void Update()
    {
        // move the projectile
        transform.position += transform.up * Speed * Time.deltaTime;
        
        // track the total distance travelled, and if greater than the max range, despawn it
        distanceTravelled += Speed * Time.deltaTime;
        if(distanceTravelled > MaxRange)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SpawnedBy && collision.gameObject == SpawnedBy.gameObject)
        {
            return;
        }

        var projectile = collision.GetComponent<Projectile>();
        if(projectile)
        {
            return;
        }

        var health = collision.GetComponent<Health>();
        if(health)
        {
            health.DoDamage(Damage);
        }

        Destroy(gameObject);
    }
}
