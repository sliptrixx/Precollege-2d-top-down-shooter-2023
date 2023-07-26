using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [field: SerializeField] public int MaxHealth { get; private set; } = 10;

    [SerializeField] UnityEvent<Health> OnDamageEvent;

    [SerializeField] UnityEvent<Health> OnDeathEvent;
    
    /// <summary>
    /// the current health of the object
    /// </summary>
    public int currentHealth { get; private set; }

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
            OnDeathEvent.Invoke(this);
        }

        OnDamageEvent.Invoke(this);
    }

    public void DoHeal(int heal)
    {
        // fancy way of healing
        DoDamage(-heal);
    }
    
    public void DestroyGameobject()
    {
        Destroy(gameObject);
    }
}
