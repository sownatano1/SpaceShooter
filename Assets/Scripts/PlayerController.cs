using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float shipSpeed = 10f;
    private float horizontalInput;
    private float verticalInput;

    public float borderX = 10;
    public float borderY = 8;

    public GameObject firePoint;
    public float projectileCooldown = 0.5f;
    float projectileTime = 0;

    public float maxHealth = 1;
    public float currentHealth;
    public Image healthBar;
    public float enemyDamage = 0.1f;

    public bool gameOver = false;

    public GameObject projectilePrefab;
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        Border();

        healthBar.fillAmount = currentHealth;

        if (currentHealth <= 0f)
        {
            gameOver = true;
        }

        //Inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Båda inputs bli en vector "movement"
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);

        if (movement.magnitude > 1)
        {
            movement = movement.normalized;
        }

        if (gameOver == false)
        {
            // Utför rörelsen med jämn hastighet
            transform.Translate(movement * Time.deltaTime * shipSpeed);
        }

        //Projectiles
        if (Input.GetKeyDown(KeyCode.Space) && projectileTime <= Time.time)    
        {
            ShootingProjectile();
            projectileTime = Time.time + projectileCooldown;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            currentHealth = currentHealth - enemyDamage;
            print("Hit");
        }
    }

    void Border()
    {
        //X Border
        if (transform.position.x > borderX)
        {
            transform.position = new Vector3(borderX, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -borderX)
        {
            transform.position = new Vector3(-borderX, transform.position.y, transform.position.z);
        }

        //Y Border
        if (transform.position.y > borderY)
        {
            transform.position = new Vector3(transform.position.x, borderY, transform.position.z);
        }

        if (transform.position.y < -borderY)
        {
            transform.position = new Vector3(transform.position.x, -borderY, transform.position.z);
        }
    }

    void ShootingProjectile()
    {
        Instantiate(projectilePrefab, firePoint.transform.position, projectilePrefab.transform.rotation);
    }
}
