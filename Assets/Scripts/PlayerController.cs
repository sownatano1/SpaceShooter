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
    void Start()
    {

    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        // B�da inputs bli en vector "movement"
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);

        // Normaliserar r�relse s� det bli p� samma hastighet.
        if (movement.magnitude > 1)
        {
            movement = movement.normalized;
        }

        // Utf�r r�relsen med j�mn hastighet
        transform.Translate(movement * Time.deltaTime * shipSpeed);
    }
}
