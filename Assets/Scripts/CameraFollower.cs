using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0f,2.6f,-6f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
