using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.PlayerLoop;
using UnityEditor;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemiesPrefabs;
    public float zSpawnPos = 40f;

    public float startDelay = 2f;
    public float spawnDelay = 1.0f;
    [Header("Asteroid")]
    public float asteroidMinStartDelay = 100f;
    public float asteroidMaxStartDelay = 250f;
    public float asteroidSpawnDelay = 4f;
    public float asteroidTime = 20f;
    public GameObject asteroidPrefabs;
    private bool isMeteoring = false;
    public GameObject asteroidUI;

    private PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isMeteoring = false;
        InvokeRepeating("SpawnEnemy", startDelay, spawnDelay);
        Invoke("GenerateMeteor", 1);
        InvokeRepeating("SpawnMeteor", 0, asteroidSpawnDelay);
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnDelay == 0.2)
        {
            spawnDelay = 0.2f;
        }
    }

    void GenerateMeteor()
    {
        float meteorRandomDelay = Random.Range(asteroidMinStartDelay, asteroidMaxStartDelay);
        Invoke("OpenDangerUI", meteorRandomDelay);
    }

    void MakeMeteoring()
    {
        isMeteoring = true;
    }

    void OpenDangerUI()
    {
        playerController.alarmSound.Play();
        asteroidUI.SetActive(true);
        Invoke("CloseDangerUI", 4);
    }
    void CloseDangerUI()
    {
        playerController.alarmSound.Stop();
        asteroidUI.SetActive(false);
        Invoke("MakeMeteoring", 4);
        CancelInvoke("OpenDangerUI");
    }

    void SpawnEnemy()
    {
        if (isMeteoring == false)
        {
            int enemiesIndex = Random.Range(0, enemiesPrefabs.Length);
            float randomPositionX = Random.Range(-10, 11);
            float randomPositionY = Random.Range(-8, 9);
            Vector3 spawnPos = new Vector3(randomPositionX, randomPositionY, zSpawnPos);
            if (playerController.gameOver == false)
            {
                Instantiate(enemiesPrefabs[enemiesIndex], spawnPos, enemiesPrefabs[enemiesIndex].transform.rotation);
            }
            GenerateMeteor();
        }
    }

    void SpawnMeteor()
    {
        if (isMeteoring == true)
        {
            float randomPositionX = Random.Range(-10, 11);
            float randomPositionY = Random.Range(-8, 9);
            Vector3 spawnPos = new Vector3(randomPositionX, randomPositionY, 100f);
            if (playerController.gameOver == false)
            {
                Instantiate(asteroidPrefabs, spawnPos, asteroidPrefabs.transform.rotation);
            }
            Invoke("RestartMeteor", asteroidTime);
            spawnDelay = spawnDelay - 0.025f;
        }
    }
    void RestartMeteor()
    {
        isMeteoring = false;
    }
}