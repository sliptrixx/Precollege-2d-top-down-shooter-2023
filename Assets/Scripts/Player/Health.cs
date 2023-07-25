using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int MaxHealth = 10;
    
    /// <summary>
    /// the current health of the object
    /// </summary>
    int currentHealth;

    private void Start()
    {
        currentHealth = MaxHealth;
    }

    public void DoDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, MaxHealth);
    }

    public void DoHeal(int heal)
    {
        // fancy way of healing
        DoDamage(-heal);
    }    
}
