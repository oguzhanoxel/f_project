using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _moveSpeed = 1.0f;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Player.Instance.IsCollected)
        {
            var direction = (Player.Instance.transform.position - transform.position).normalized;
            _rigidbody.velocity = direction.normalized * _moveSpeed;
        }
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }
}
