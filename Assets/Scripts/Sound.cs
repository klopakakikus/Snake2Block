using UnityEngine;

public class Sound : MonoBehaviour
{
    [Min(0)]
    public float Volume;
    [Min(0)]
    public float Delay;

    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        _audio.PlayDelayed(Delay);
    }

    public void MusicOff()
    {
        _audio.Stop();
    }
}