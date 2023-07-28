using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveUI : MonoBehaviour
{
    [SerializeField] TMP_Text WaveText;
    [SerializeField] TMP_Text EnemiesRemainingText;

    [Header("References")]
    [SerializeField] EnemyManager enemyManager;

    public void UpdateWaveText()
    {
        WaveText.text = $"Wave {enemyManager.CurrentWave}";
    }

    public void UpdateEnemiesRemainingText()
    {
        EnemiesRemainingText.text = $"Enemies Left: {enemyManager.Enemies.Count}";
    }
}
