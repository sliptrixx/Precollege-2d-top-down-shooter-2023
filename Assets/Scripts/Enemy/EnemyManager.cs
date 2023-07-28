using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Responsible for spawning enemies
/// </summary>
public class EnemyManager : MonoBehaviour
{
    [SerializeField] AnimationCurve Waves;
    [SerializeField] float SpawnRadius;

    [Header("Events")]
    [SerializeField] public UnityEvent OnNewWave;

    [Header("References")]
    [SerializeField] Transform player;
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] SplatManager splatManager;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] WaveUI waveUI;

    /// <summary>
    /// A list of enemies that are currently on scene
    /// </summary>
    public List<GameObject> Enemies { get; protected set; } = new List<GameObject>();

    /// <summary>
    /// The current wave that the player is encountering
    /// </summary>
    public int CurrentWave { get; protected set; } = 0;

    private void Start()
    {
        SpawnNewWave();
    }

    /// <summary>
    /// Perform a new wave check if possible
    /// </summary>
    void SpawnNewWave()
    {
        // there are enemies left, don't spawn a new wave
        if(Enemies.Count > 0) { return; }

        // increment the wave count
        CurrentWave++;

        // get the number of enemies to spawn
        int numberOfEnemies = Mathf.RoundToInt(Waves.Evaluate(CurrentWave));

        // loop through the number of enemies and spawn it
        for(int i = 0; i < numberOfEnemies; i++)
        {
            SpawnEnemy();
        }

        // invoke an event letting everyone know that a new wave is up
        OnNewWave?.Invoke();
    }

    /// <summary>
    /// Spawn a new enemy around the player
    /// </summary>
    void SpawnEnemy()
    {
        // instantiate the enemy
        var enemy = Instantiate(EnemyPrefab);

        // move the enemy some where around the player
        enemy.transform.position = player.transform.position + (Vector3) (Random.insideUnitCircle * SpawnRadius);

        // make the enemy subscribe to splat, score manager, and the enemy manager on it's death
        var enemyHealth = enemy.GetComponent<Health>();
        
        if(splatManager && enemyHealth)
        {
            enemyHealth.OnDeathEvent.AddListener(splatManager.HandleOnDeath);
            enemyHealth.OnDeathEvent.AddListener((health) => scoreManager.OnUnitDeath());
            enemyHealth.OnDeathEvent.AddListener((health) => waveUI.UpdateEnemiesRemainingText()); 
            enemyHealth.OnDeathEvent.AddListener(OnEnemyDeath);
        }

        // add it to the list of enemies
        Enemies.Add(enemy);
    }

    /// <summary>
    /// Handle the death event of an enemy
    /// </summary>
    /// <param name="health">The health component of the enemy, passed as a parameter by the on death event</param>
    void OnEnemyDeath(Health health)
    {
        // remove the enemy from the list of gameobject
        Enemies.Remove(health.gameObject);

        // no more enemies left, spawn a new wave
        if(Enemies.Count <= 0)
        {
            SpawnNewWave();
        }
    }

    private void OnValidate()
    {
        Waves.ClearKeys();
        Waves.AddKey(1, 3);
        Waves.AddKey(2, 4);
        Waves.AddKey(3, 5);
        Waves.AddKey(4, 5);
        Waves.AddKey(5, 6);
    }
}
