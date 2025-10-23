using UnityEngine;

public class Shield : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset = new Vector3(0f, 0f, 0f);
    public float shieldCooldown = 8f;
    public GameObject shieldExplosion;
    private PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {   
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        player = GameObject.FindWithTag("Player");
        InvokeRepeating("DestroyCooldown", shieldCooldown, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.gameObject.transform.position + offset;
    }
    void DestroyCooldown()
    {
        Destroy(gameObject);
        Instantiate(shieldExplosion, transform.position, shieldExplosion.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Instantiate(shieldExplosion, other.transform.position, shieldExplosion.transform.rotation);
            playerController.IncreaseKills(1);
            playerController.IncreaseScore(5);
        }

        if (other.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
            Instantiate(shieldExplosion, other.transform.position, shieldExplosion.transform.rotation);
            playerController.IncreaseScore(2);
        }

        if (other.CompareTag("Health"))
        {
            Destroy(other.gameObject);
            playerController.currentHealth = playerController.currentHealth + 0.1f;
        }

        if (other.CompareTag("Asteroid"))
        {
            Destroy(other.gameObject);
        }
    }
}
