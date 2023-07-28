using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] float DistanceToFollow = 3;
    [SerializeField] float ShootDistance = 6;

    Unit unit;

    void Start()
    {
        Target = FindObjectOfType<PlayerController>().transform;
        unit = GetComponent<Unit>();
    }

    void Update()
    {
        if(Target == null) { return; }

        // early exit if the enemy is very far away
        if(Vector3.Distance(Target.position, transform.position) > DistanceToFollow) { return; }

        // get the direction to target
        var dir = Target.position - transform.position;
        dir.Normalize();

        // perform raycast
        RaycastHit2D[] hitInfos = Physics2D.RaycastAll(transform.position, dir);
        foreach(var hitInfo in hitInfos)
        {
            var hit_enemy = hitInfo.transform.GetComponent<EnemyAI>();
            if(hit_enemy == this)
            {
                continue;
            }

            if(hitInfo.transform != Target)
            { 
                return; 
            }
        }

        // Look at the target
        transform.up = dir;

        // Move towards the target
        unit.Move(dir);

        if (Vector3.Distance(Target.position, transform.position) <= ShootDistance) 
        {
            unit.StartAiming();
            unit.FireWeapon();
        }
        else
        {
            unit.StopAiming();
        }

    }
}
