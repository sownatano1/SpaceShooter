using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject enemyProjectilePrefab;
    public float minFireCooldown = 3;
    public float maxFireCooldown = 6;
    private float enemyFireTime = 0;
    public GameObject firePos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        float enemyFireCooldown = Random.Range(minFireCooldown, maxFireCooldown);
        if (enemyFireTime <= Time.time)
        {
            enemyFireTime = enemyFireCooldown + Time.time;
            ShootingProjectile();
        }

        if (transform.position.z < 6)
        {
            Destroy(firePos);
        }
    }

    void ShootingProjectile()
    {
        if (firePos != null)
        {
            Instantiate(enemyProjectilePrefab, firePos.transform.position, enemyProjectilePrefab.transform.rotation);
        }
        else
        {
            print("Can't shoot, too close");
        }
    }
}
