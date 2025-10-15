using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float shipSpeed = 10f;
    public float horizontalInput;
    public float verticalInput;

    public float borderX = 10;
    public float borderY = 8;

    public GameObject projectilePrefab;
    void Start()
    {

    }

    void Update()
    {
        //Inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Båda inputs bli en vector "movement"
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);

        if (movement.magnitude > 1)
        {
            movement = movement.normalized;
        }

        // Utför rörelsen med jämn hastighet
        transform.Translate(movement * Time.deltaTime * shipSpeed);

        //X Border
        if (transform.position.x > borderX)
        {
            transform.position = new Vector3(borderX , transform.position.y, transform.position.z);
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

        //Projectiles
        if (Input.GetKeyDown(KeyCode.Space))    
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
