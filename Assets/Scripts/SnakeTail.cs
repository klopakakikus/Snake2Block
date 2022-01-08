using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public Transform SnakeHead;
    public float BodyDiameter;

    public AudioClip FoodSound;

    private List<Transform> _snakeBody = new List<Transform>();
    private List<Vector3> _positions = new List<Vector3>();

    void Start() 
    {
        _positions.Add(SnakeHead.position);
    }

    void Update()
    {
        float _distance = ((Vector3)SnakeHead.position - _positions[0]).magnitude;

        if (_distance > BodyDiameter)
        {
            Vector3 direction = ((Vector3)SnakeHead.position - _positions[0]).normalized;

            _positions.Insert(0, _positions[0] + direction * BodyDiameter);
            _positions.RemoveAt(_positions.Count - 1);
            _distance -= BodyDiameter;
        }

        for (int i = 0; i < _snakeBody.Count; i++)
        {
            _snakeBody[i].position = Vector3.Lerp(_positions[i + 1], _positions[i], _distance / BodyDiameter);
        }
 
    }

    public void AddBody()
    {
        Transform body = Instantiate(SnakeHead, _positions[_positions.Count - 1], Quaternion.identity, transform);
        _snakeBody.Add(body);
        _positions.Add(body.position);

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Food")
        {
            var audio = GetComponent<AudioSource>();
            audio.PlayOneShot(FoodSound);
        }
    }

    public void RemoveBody()
    {
        Destroy(_snakeBody[0].gameObject);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.05f);
        _snakeBody.RemoveAt(0);
        _positions.RemoveAt(1);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}