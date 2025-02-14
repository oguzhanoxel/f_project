using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    
    private bool _isWalking = false;
    
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
        transform.Rotate(0f, Random.Range(0f, 360f), 0);
    }

    void Update()
    {
        if (Player.Instance.IsCollected)
        {
            _agent.destination = Player.Instance.transform.position;
            if (!_isWalking)
            {
                _isWalking = true;
                _animator.SetTrigger(Animations.Walk);
            }
        }
    }
    
    public void Stop()
    {
        _agent.speed = 0;
        _animator.SetTrigger(Animations.Idle);
    }
}
