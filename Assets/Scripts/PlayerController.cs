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

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.Translate(Vector3.right * Time.deltaTime * shipSpeed * horizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * shipSpeed * verticalInput);
    }
}
