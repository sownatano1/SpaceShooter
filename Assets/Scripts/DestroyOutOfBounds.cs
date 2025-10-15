using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public int distanceToDestroy = 0;
    public bool isEnemy = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
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
    }
}
