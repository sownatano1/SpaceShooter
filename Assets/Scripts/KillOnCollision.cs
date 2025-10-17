using UnityEngine;

public class KillOnCollision : MonoBehaviour
{
    public bool isEnemyBullet = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (other.CompareTag("Enemy") && isEnemyBullet == false)
        {
            Destroy(other.gameObject);
        }
    }
}
