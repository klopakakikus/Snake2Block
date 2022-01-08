using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform SnakeHead;

    private Vector3 offset;
    
    void Start()
    {
        offset = transform.position - SnakeHead.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(0, SnakeHead.position.y + offset.y, SnakeHead.position.z + offset.z);
    }
}