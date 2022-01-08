using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SnakeMovement : MonoBehaviour
{
    public float ForwardSpeed; 
    public float Sensitivity;

    public static int Length=4;

    public TextMeshPro PointsText;

    
    private Camera _camera;
    private Rigidbody _rigidbody;
    public static SnakeTail _componentSnakeTail;

    private Vector3 _touchLastPosition;
    private float _sidewaysSpeed;

    public Game Game;
    public Sound Sound;
    public AudioClip SoundCollisionOnBlock;
    
    void Start()
    {
        Length = 4;
        _camera = Camera.main;
        _rigidbody = GetComponent<Rigidbody>();
        _componentSnakeTail = GetComponent<SnakeTail>();

        for (int i = 1; i < Length; i++) _componentSnakeTail.AddBody();
        PointsText.SetText(Length.ToString());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _touchLastPosition = _camera.ScreenToViewportPoint(Input.mousePosition);
        
        else if (Input.GetMouseButtonUp(0))
            _sidewaysSpeed = 0;

        else if (Input.GetMouseButton(0))
        {
            Vector3 delta = (Vector3)_camera.ScreenToViewportPoint(Input.mousePosition) - _touchLastPosition;
            _sidewaysSpeed += delta.x * Sensitivity;
            _touchLastPosition = _camera.ScreenToViewportPoint(Input.mousePosition);
        }

        PointsText.SetText(Length.ToString());
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_sidewaysSpeed) > 4) _sidewaysSpeed = 4 * Mathf.Sign(_sidewaysSpeed);
        _rigidbody.velocity = new Vector3(_sidewaysSpeed * 10, 0, ForwardSpeed);
        _sidewaysSpeed = 0;
    }

    public void Die()
    {
        Game.OnPlayerDied();
        _rigidbody.velocity = Vector3.zero;
        Sound.MusicOff();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
           
            var audio = GetComponent<AudioSource>();
            audio.PlayOneShot(SoundCollisionOnBlock);
            Game.Count();
        }
 
        if (Length == 0)
        {
            Die();
        }
    }

    public void ReachFinish()
    {
        Game.OnPlayerReachedFinish();
        _rigidbody.velocity = Vector3.zero;
       
    }
}