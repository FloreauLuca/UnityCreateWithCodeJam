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
    [SerializeField] private Doors door;
    private List<GameObject> enemies = new List<GameObject>();
    private bool waveStarted = false;

    

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
        bool allDead = true;
        if (enemies.Count > 0)
        {
            foreach (GameObject enemy in enemies)
            {
                if (enemy)
                {
                    allDead = false;
                }
            }
            if (allDead && door.ForcedLocked)
            {
                if (waves.Count <= currentWaveIndex)
                {
                    gameManager.Win();
                }
                door.ForcedLocked = false;
                door.OpenDoor();
            }
        }
    }

    void StartNewWave()
    {
        if (waves.Count >= currentWaveIndex && currentWaveIndex > 0)
        {
            waves[currentWaveIndex - 1].waveFinish.enabled = true;
        }
        if (waves.Count > currentWaveIndex && !waveStarted)
        {
            StartCoroutine(LaunchWave(waves[currentWaveIndex]));
        }
    }

    IEnumerator LaunchWave(Wave wave)
    {
        door.ForcedLocked = true;
        door.CloseDoor();
        waveStarted = true;
        int currentEnemyCount = 0;
        while (currentEnemyCount < wave.totalEnnemies)
        {
            yield return new WaitForSeconds(wave.coolDown);
            for (int i = 0; i < wave.enemiesGroup; i++)
            {
                enemies.Add(Instantiate(wave.prefab, (Vector2)wave.spawnPoint.position, Quaternion.identity));
                door.ForcedLocked = true;
                door.CloseDoor();
                currentEnemyCount++;
            }
        }
        currentWaveIndex++;
        waveStarted = false;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            StartNewWave();
        }
    }
}
