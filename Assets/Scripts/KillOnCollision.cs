using TMPro;
using UnityEngine;

public class KillOnCollision : MonoBehaviour
{
    public bool isEnemyBullet = false;
    private PlayerController playerController;
    public GameObject explosion;
    public bool destroyable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        DestroyIfDestroyable();

        if (other.CompareTag("Enemy") && isEnemyBullet == false)
        {
            Destroy(other.gameObject);
            Instantiate(explosion, transform.position, explosion.transform.rotation);

            if (destroyable == true)
            {
                playerController.IncreaseScore(5);
                playerController.IncreaseKills(1);
            }

            if (destroyable == false)
            {
                playerController.currentHealth = playerController.currentHealth - playerController.enemyDamage;
            }
        }

        if (other.CompareTag("Health"))
        {
            playerController.currentHealth = playerController.currentHealth + 0.1f;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("FireRateBoost"))
        {
            playerController.IncreaseFirePoints(1);
            playerController.projectileCooldown = playerController.projectileCooldown - 0.05f;
            Destroy(other.gameObject);
        }
    }

    void DestroyIfDestroyable()
    {
        if (destroyable == true)
        {
            Destroy(gameObject);
        }
    }
}
