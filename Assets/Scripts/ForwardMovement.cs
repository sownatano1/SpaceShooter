using UnityEngine;
using UnityEditor;

public class ForwardMovement : MonoBehaviour
{
    public float speed = 5;
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
        if (isFoward == true)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (isFoward == false)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        if (playerController.gameOver == true)
        {
            Destroy(gameObject);
        }
    }
}
