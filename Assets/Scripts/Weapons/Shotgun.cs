using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] int NumberOfProjectilesToFire = 3;

    protected override void OnFire()
    {
        float deg = -15;
        float increments = 15;

        for(int i = 0; i < NumberOfProjectilesToFire; i++)
        {
            SpawnProjectile(deg);
            deg += increments;
        }
    }
}
