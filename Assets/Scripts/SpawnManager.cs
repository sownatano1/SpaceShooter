using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.PlayerLoop;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemiesPrefabs;
    public float zSpawnPos = 40f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            int enemiesIndex = Random.Range(0, enemiesPrefabs.Length);
            float randomPositionX = Random.Range(-10, 11);
            float randomPositionY = Random.Range(-8, 9);
            Vector3 spawnPos = new Vector3(randomPositionX, randomPositionY, zSpawnPos);
            Instantiate(enemiesPrefabs[enemiesIndex], spawnPos , enemiesPrefabs[enemiesIndex].transform.rotation);
        }
    }
}
