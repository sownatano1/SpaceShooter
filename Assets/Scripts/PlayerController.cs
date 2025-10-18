using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
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
    public GameObject gameOverUI;
    public GameObject healthBarUI;
    public Button restartButton;

    private float tiltAngle = 10f;
    private float tiltSpeed = 3f;
    private float targetTilt = 0f;
    private float currentTilt = 0f;

    public GameObject projectilePrefab;
    void Start()
    {
        currentHealth = maxHealth;
        restartButton.onClick.AddListener(RestartGame);
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

        if (gameOver == true)
        {
            gameOverUI.SetActive(true);
            healthBarUI.SetActive(false);
        }

        targetTilt = -horizontalInput * tiltAngle;
        currentTilt = Mathf.Lerp(targetTilt, currentTilt, Time.deltaTime * tiltSpeed);
        transform.rotation = Quaternion.Euler(0f,0f,currentTilt).normalized;
    }
    void RestartGame()
    {
        gameOverUI.SetActive(false);
        healthBarUI.SetActive(true);
        currentHealth = currentHealth * 0 + maxHealth;
        gameOver = false;

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
