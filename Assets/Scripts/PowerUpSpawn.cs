using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.PlayerLoop;

public class PowerUpSpawn : MonoBehaviour
{
    public GameObject[] powerUpPrefabs;
    public float zSpawnPos = 40f;

    public float startDelay = 20f;
    public float spawnDelay = 15.0f;
    public float minSpawnDelay = 12.0f;
    public float maxSpawnDelay = 25.0f;

    private PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float randomSpawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
        InvokeRepeating("SpawnEnemy", startDelay, randomSpawnDelay);
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        int powerIndex = Random.Range(0, powerUpPrefabs.Length);
        float randomPositionX = Random.Range(-10, 11);
        float randomPositionY = Random.Range(-8, 9);
        Vector3 spawnPos = new Vector3(randomPositionX, randomPositionY, zSpawnPos);
        if (playerController.gameOver == false)
        {
            Instantiate(powerUpPrefabs[powerIndex], spawnPos, powerUpPrefabs[powerIndex].transform.rotation);
        }
    }
}
