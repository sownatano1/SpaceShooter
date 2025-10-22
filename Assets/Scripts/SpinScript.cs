using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class SpinScript : MonoBehaviour
{
    public float spinSpeed = 1f;
    public bool rotateXAxis = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateXAxis == false)
        {
            transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
        }

        if (rotateXAxis == true)
        {
            transform.Rotate(Vector3.right * spinSpeed * Time.deltaTime);
        }
    }
}
