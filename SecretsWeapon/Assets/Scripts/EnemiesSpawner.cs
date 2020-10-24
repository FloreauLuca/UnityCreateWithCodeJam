using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
struct Wave
{
    public float totalEnnemies;
    public int enemiesGroup;
    public float coolDown;
    public GameObject prefab;
    public Transform spawnPoint;
    public SpriteRenderer waveFinish;
}

public class EnemiesSpawner : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private int currentWaveIndex = 0;
    [SerializeField] private List<Wave> waves;


    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        foreach (Wave wave in waves) {
            wave.waveFinish.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartNewWave()
    {
        if (waves.Count >= currentWaveIndex && currentWaveIndex > 0)
        {
            waves[currentWaveIndex - 1].waveFinish.enabled = true;
        }
        if (waves.Count > currentWaveIndex)
        {
            StartCoroutine(LaunchWave(waves[currentWaveIndex]));
        }
    }

    IEnumerator LaunchWave(Wave wave)
    {
        int currentEnemyCount = 0;
        while (currentEnemyCount < wave.totalEnnemies) {
            yield return new WaitForSeconds(wave.coolDown);
            for (int i = 0; i < wave.enemiesGroup; i++)
            {
                Instantiate(wave.prefab, (Vector2)wave.spawnPoint.position + Vector2.one * i, Quaternion.identity);
                currentEnemyCount++;
            }
        }
        currentWaveIndex++;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            StartNewWave();
        }
    }
}
