using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class Blocks : MonoBehaviour
{
    int _blockPoints;
    public TextMeshPro blockText;

    Renderer _renderer;
    Gradient _gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;

    void Start() 
    {
        _blockPoints = Random.Range(1, 15);
        blockText.SetText(_blockPoints.ToString());

        _renderer = GetComponent<Renderer>();

        _gradient = new Gradient();
        colorKey = new GradientColorKey[2];
        colorKey[0].color = Color.blue;
        colorKey[0].time = 0.0f;
        colorKey[1].color = Color.yellow;
        colorKey[1].time = 1.0f;

        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 0.0f;
        alphaKey[1].time = 1.0f;

        _gradient.SetKeys(colorKey, alphaKey);
        _renderer.material.color = _gradient.Evaluate(_blockPoints / 15f);
    }

    private void OnTriggerEnter(Collider other)
    { 
        SnakeMovement.Length--;
        SnakeMovement._componentSnakeTail.RemoveBody();
        _blockPoints--;
        blockText.SetText(_blockPoints.ToString());

        if (_blockPoints < 1)
        {
            Destroy(gameObject);
        }
    }
}