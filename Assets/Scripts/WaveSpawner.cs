
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    [System.Serializable]
    public class Wave
    {
        public Enemy[] enemies;
        public int count;
        public float timeBetweenSpawns;
    }

    public string level;
    public Text textLevel;

    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeBetweenWaves;

    private TransitionScene transitionScene;

    public string scene;

    private Wave currentWave;
    private int currentWaveIndex;
    private Transform player;

    private bool spawningFinished;



    private void Start()
    {
        StartCoroutine(ShowMessage(level, 3));
        player = GameObject.FindWithTag("Player").transform;
        StartCoroutine(StartNextWave(currentWaveIndex));
        transitionScene = FindObjectOfType<TransitionScene>();

    }

    IEnumerator ShowMessage(string message, float delay)
    {
        textLevel.text = message;
        textLevel.enabled = true;
        yield return new WaitForSeconds(delay);
        textLevel.enabled = false;
    }

    IEnumerator StartNextWave(int waveIndex)
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(waveIndex));
    }

    IEnumerator SpawnWave(int waveIndex)
    {
        currentWave = waves[waveIndex];

        for (int i = 0; i < currentWave.count; i++)
        {
            if (player == null)
            {
                yield break;
            }
            Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomSpawnPoint.position, transform.rotation);

            if (i == currentWave.count - 1)
            {
                spawningFinished = true;
            }
            else
            {
                spawningFinished = false;
            }

            yield return new WaitForSeconds(currentWave.timeBetweenSpawns);

        }
    }

    private void Update()
    {

        if (spawningFinished == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            spawningFinished = false;
            if (currentWaveIndex + 1 < waves.Length)
            {
                currentWaveIndex++;
                StartCoroutine(StartNextWave(currentWaveIndex));
            }
            else
            {
                transitionScene.LoadScene(scene);

            }
        }
    }
}