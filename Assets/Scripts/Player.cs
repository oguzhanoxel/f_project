using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public bool IsCollected { get; private set; } = false;
    
    private Animator _animator;
    private Vector3 _spawnPos = new Vector3(0, 0, -8.0f);
    private float _moveSpeed = 1f;
    private Rigidbody _rigidbody;
    private bool _isWalking = false;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Door) && IsCollected) Escaped(other);
        if (other.CompareTag(Tags.Collectible)) Collect(other);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(Tags.Enemy) && IsCollected) Dead(); 
    }
    
    private void Move()
    {
        var direction = Vector3.zero;
        
        if (Input.GetKey(KeyCode.LeftShift)) _moveSpeed = 3f;
        else _moveSpeed = 1f;
        
        if (Input.GetKey(KeyCode.W)) direction += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) direction += Vector3.back;
        if (Input.GetKey(KeyCode.A)) direction += Vector3.left;
        if (Input.GetKey(KeyCode.D)) direction += Vector3.right;

        if (_rigidbody.velocity.magnitude < 0.1f) TriggerIdleAnimation();
        else if (2.8f >= _rigidbody.velocity.magnitude && _rigidbody.velocity.magnitude >= 0.1f) TriggerWalkAnimation();
        else TriggerRunAnimation();
        
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
        
        
        _rigidbody.velocity = direction.normalized * _moveSpeed;
    }

    private void Collect(Collider other)
    {
        other.gameObject.SetActive(false);
        IsCollected = true;
        GameDirector.Instance.levelManager.SetActiveDoor(true);
    }

    public void ResetPlayer()
    {
        gameObject.transform.position = _spawnPos;
        gameObject.SetActive(true);
        IsCollected = false;
    }

    private void Escaped(Collider other)
    {
        gameObject.SetActive(false);
        GameDirector.Instance.LevelCompleted();
    }

    private void Dead()
    {
        gameObject.SetActive(false);
        GameDirector.Instance.LevelFailed();
    }

    private void TriggerWalkAnimation()
    {
        if (!_isWalking)
        {
            _animator.SetTrigger(Animations.Walk);
            _isWalking = true;
        }
    }

    private void TriggerIdleAnimation()
    {
        if (_isWalking)
        {
            _animator.SetTrigger(Animations.Idle);
            _isWalking = false;
        }
    }

    private void TriggerRunAnimation()
    {
        if (!_isWalking)
        {
            _animator.SetTrigger(Animations.Run);
            _isWalking = true;
        }
    }
}
