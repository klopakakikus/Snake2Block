using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.TryGetComponent(out SnakeMovement snake)) return;
        snake.ReachFinish();
    }
}
