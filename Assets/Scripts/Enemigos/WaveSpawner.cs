using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public float timeBetweenWaves = 15f;
    private float countdown = 15f;

    [SerializeField]
    private GameObject[] enemyPrefab = new GameObject[1];
    [SerializeField]
    private Transform spawnPoint;

    public GameObject losePanel, mainPanel;

    private int waveNo = 0;
    [SerializeField] private int wavesToWin;

    public Text waveText;
    private AudioSource audioWaves;

    private void Awake()
    {
        waveText = GameObject.FindGameObjectWithTag("WaveCounter").GetComponent<Text>();
        audioWaves = GameObject.Find("SpawnPoint").GetComponent<AudioSource>();
        Debug.Log(audioWaves);
    }

    void Update()
    {
        if (countdown <= 0f)
        {
            if(waveNo < wavesToWin)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
                waveText.text = "Oleada " + waveNo;
            }
            else
            {
                if (GameObject.FindGameObjectsWithTag("Enemy") == null)
                {
                    mainPanel.SetActive(false);
                    losePanel.SetActive(true);
                }
            }
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        audioWaves.Play();
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
