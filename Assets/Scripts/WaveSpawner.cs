using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public float timeBetweenWaves = 10f;
    private float countdown = 3f;

    [SerializeField]
    private GameObject[] enemyPrefab = new GameObject[1];
    [SerializeField]
    private Transform spawnPoint;

    private int waveNo = 1;

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveNo ; i++)
        {
            SpawnEnemy();

            yield return new WaitForSeconds(0.5f);
        }

        waveNo++;
    }

    private void SpawnEnemy()
    {
        int randomEnemy = Random.Range(0, enemyPrefab.Length);

        Debug.Log("Spawneo el enemigo " + randomEnemy);
        Instantiate(enemyPrefab[randomEnemy], spawnPoint.position, spawnPoint.rotation);
    }
}
