using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class Food : MonoBehaviour
{
    private int _foodPoints;

    public TextMeshPro foodText;
    public AudioClip FoodSound;
    
    void Start()
    {
        _foodPoints = Random.Range(1, 15);
        foodText.SetText(_foodPoints.ToString());
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < _foodPoints; i++)
        {
            SnakeMovement.Length++;
            SnakeMovement._componentSnakeTail.AddBody();
        }

        Destroy(gameObject);
    }
}