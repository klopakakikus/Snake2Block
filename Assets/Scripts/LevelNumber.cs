using UnityEngine.UI;
using UnityEngine;

public class LevelNumber : MonoBehaviour
{
    public Text Text;
    public Game Game;

    void Start()
    {
        Text.text = "Level " + Game.LevelIndex.ToString();
    }
}