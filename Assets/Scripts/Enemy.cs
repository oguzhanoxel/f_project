using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Rigidbody _rigidbody;
    private float _moveSpeed = 1.0f;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Player.Instance.IsCollected)
        {
            _agent.destination = Player.Instance.transform.position;
        }
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        _agent.speed = 0;
    }
}
