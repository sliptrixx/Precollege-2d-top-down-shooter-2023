using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatManager : MonoBehaviour
{
    [SerializeField] GameObject SplatPrefab;

    public void HandleOnDeath(Health health)
    {
        AddSplat(health.transform.position);
    }

    public void AddSplat(Vector3 position)
    {
        Instantiate(SplatPrefab, position, Quaternion.identity);
    }
}
