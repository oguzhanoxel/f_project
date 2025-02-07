using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public bool IsCollected { get; private set; } = false;
    
    private float _moveSpeed = 2f;
    private Rigidbody _rigidbody;
    
    void Start()
    {
        Instance = this;
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var direction = Vector3.zero;
        
        if (Input.GetKey(KeyCode.LeftShift)) _moveSpeed = 5f;
        else _moveSpeed = 2f;
        
        if (Input.GetKey(KeyCode.W)) direction += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) direction += Vector3.back;
        if (Input.GetKey(KeyCode.A)) direction += Vector3.left;
        if (Input.GetKey(KeyCode.D)) direction += Vector3.right;
            
        _rigidbody.velocity = direction.normalized * _moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Enemy)) gameObject.SetActive(false);
        if (other.CompareTag(Tags.Door) && IsCollected) Escaped(other);
        if (other.CompareTag(Tags.Collectible)) Collect(other);
    }

    private void Collect(Collider other)
    {
        other.gameObject.SetActive(false);
        IsCollected = true;
        GameDirector.Instance.levelManager.SetActiveDoor(true);
    }

    private void Escaped(Collider other)
    {
        gameObject.SetActive(false);
        GameDirector.Instance.LevelCompleted();
    }
}
