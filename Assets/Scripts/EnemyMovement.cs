using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Collider2D _wallCheckCollider;

    private Rigidbody2D _rigidbody2D;

    private enum MoveDirection
    {
        Left = -1,
        Right = 1
    }
    private MoveDirection _moveDirection = MoveDirection.Left;

    private void Awake() 
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();    
    }

    private void Update()
    {
        CheckWalls();
        Move();
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2((int)_moveDirection * _movementSpeed * Time.deltaTime, _rigidbody2D.velocity.y);
    }

    private void SwapDirection()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        if (_moveDirection == MoveDirection.Left)
        {
            _moveDirection = MoveDirection.Right;
        }
        else
        {
            _moveDirection = MoveDirection.Left;
        }
    }

    private void CheckWalls()
    {
        LayerMask wallLayer = LayerMask.GetMask("Ground");
        if (_wallCheckCollider.IsTouchingLayers(wallLayer))
        {
            SwapDirection();
        }
    }
}
