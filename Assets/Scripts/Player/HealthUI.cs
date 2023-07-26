using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Image HealthBarUI;

    public void HandleOnDamageTaken(Health health)
    {
        HealthBarUI.fillAmount = (float)health.currentHealth / health.MaxHealth;
    }
}
