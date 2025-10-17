using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletTarget : MonoBehaviour
{
    public float speed = 1f;
    public float followingSpeed = 6f;
    public GameObject player;
    private Transform playerObject;
    private Vector3 direction;

    private PlayerController playerController;

    public float backSpeed = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        player = GameObject.Find("Player");
        
        playerObject = player.transform;

        if (player != null)
        {
            playerObject = playerObject.transform;
            
            direction = (playerObject.position - transform.position).normalized;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            
            transform.position += direction * speed * Time.deltaTime;
        }
    
        if (playerController.gameOver == true)
        {
            Destroy(gameObject);
        }
    }
}
