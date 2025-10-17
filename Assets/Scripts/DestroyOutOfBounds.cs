using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public int distanceToDestroy = 0;
    public bool isEnemy = false;

    void Start()
    {

    }

    void Update()
    {
        if (transform.position.z < distanceToDestroy && isEnemy == true)
        {
            Destroy(gameObject);
        }

        if (transform.position.z > distanceToDestroy && isEnemy == false)
        {
            Destroy(gameObject);
        }

        if (transform.position.y > 20)
        {
            Destroy(gameObject);
        }

        if (transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }
}