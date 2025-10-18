using UnityEngine;
using UnityEditor;
using System.Runtime.CompilerServices;

public class ForwardMovement : MonoBehaviour
{
    public float minSpeed = 4;
    public float maxSpeed = 6;
    public bool isFoward = true;
    private PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        if (isFoward == true)
        {
            transform.Translate(Vector3.forward * randomSpeed * Time.deltaTime);
        }

        if (isFoward == false)
        {
            transform.Translate(Vector3.back * randomSpeed * Time.deltaTime);
        }

        if (playerController.gameOver == true)
        {
            Destroy(gameObject);
        }
    }
}
