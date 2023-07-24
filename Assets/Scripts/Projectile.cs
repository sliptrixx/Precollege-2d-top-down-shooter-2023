using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float MaxRange;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject != SpawnedBy.gameObject)
        {
            Destroy(gameObject);
        }
    }
}
