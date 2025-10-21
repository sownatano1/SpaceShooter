using System.Net.Sockets;
using TMPro;
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
    public GameObject projectilePrefab;

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

    public GameObject healthPowerUp;

    public TextMeshProUGUI fireSpeedTMP;
    private int fireSpeedPoints = 1;
    public TextMeshProUGUI pointsText; 
    public TextMeshProUGUI totalPointText;
    private int points = 0;
    public TextMeshProUGUI killsText;
    private int kills = 0;

    public Camera camera;
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
        if (Input.GetKey(KeyCode.Space) && projectileTime <= Time.time)
        {
            ShootingProjectile();
            projectileTime = Time.time + projectileCooldown;
        }

        if (gameOver == true)
        {
            gameOverUI.SetActive(true);
            healthBarUI.SetActive(false);
        }

        //Spaceship tilt to the sides
        targetTilt = -horizontalInput * tiltAngle;
        currentTilt = Mathf.Lerp(targetTilt, currentTilt, Time.deltaTime * tiltSpeed);
        transform.rotation = Quaternion.Euler(0f, 0f, currentTilt).normalized;
    }

    public void IncreaseFirePoints(int amount)
    {
        fireSpeedPoints += amount;
        fireSpeedTMP.text = fireSpeedPoints.ToString();

        if (projectileCooldown <= 0.2f)
        {
            projectileCooldown = 0.2f;
            fireSpeedTMP.text = "MAX";
        }
    }
    public void IncreaseScore(int amount)
    {
        points += amount;
        pointsText.text = points.ToString();
        totalPointText.text = points.ToString();
    }

    public void IncreaseKills(int amount)
    {
        kills += amount;
        killsText.text = kills.ToString();
    }

    void RestartGame()
    {
        gameOverUI.SetActive(false);
        healthBarUI.SetActive(true);
        currentHealth = currentHealth * 0 + maxHealth;
        gameOver = false;
        projectileCooldown = 0.5f;
        kills = 0;
        fireSpeedPoints = 1;
        points = 0;
        killsText.text = "0";
        pointsText.text = "0";
        fireSpeedTMP.text = "1";
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
