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

        // when current health is 0, destroy the object attached to the health component
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DoHeal(int heal)
    {
        // fancy way of healing
        DoDamage(-heal);
    }    
}
