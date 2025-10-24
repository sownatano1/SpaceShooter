using TMPro;
using UnityEngine;

public class KillOnCollision : MonoBehaviour
{
    public bool isEnemyBullet = false;
    private PlayerController playerController;
    public GameObject explosion;
    public GameObject shieldExplosion;
    public GameObject shield;
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
        if (destroyable == true && other.gameObject.CompareTag("ShieldPlayer") == false)
        {
            Destroy(gameObject);
            playerController.RandomExplosionSound();
        }

        if (other.CompareTag("Enemy") && isEnemyBullet == false)
        {
            Destroy(other.gameObject);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            playerController.RandomExplosionSound();

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

        if (other.CompareTag("EnemyBullet") && isEnemyBullet == false)
        {
            Destroy(other.gameObject);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            playerController.RandomExplosionSound();

            if (destroyable == true)
            {
                playerController.IncreaseScore(2);
            }

            if (destroyable == false)
            {
                playerController.currentHealth = playerController.currentHealth - playerController.enemyDamage;
            }
        }

        if (other.CompareTag("Health"))
        {
            playerController.currentHealth = playerController.currentHealth + 0.2f;
            Destroy(other.gameObject);
            playerController.healthSound.Play();
        }

        if (other.CompareTag("FireRateBoost") && isEnemyBullet == false)
        {
            playerController.IncreaseFirePoints(1);
            playerController.projectileCooldown = playerController.projectileCooldown - 0.05f;
            Destroy(other.gameObject);
            playerController.powerUpSound.Play();
        }

        if (other.CompareTag("Shield") && isEnemyBullet == false)
        {
            Instantiate(shieldExplosion, transform.position, shieldExplosion.transform.rotation);
            Destroy(other.gameObject);
            Instantiate(shield);
            playerController.shieldSound.Play();
        }

        if (other.CompareTag("Asteroid"))
        {
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            playerController.RandomExplosionSound();
            if (destroyable == true)
            {
                Destroy(gameObject);
            }
            if (destroyable == false)
            {
                playerController.currentHealth = playerController.currentHealth - playerController.asteroidDamage;
            }
        }
    }
}
