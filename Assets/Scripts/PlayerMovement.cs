using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D) ,typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;
    private Animator _animator;

    private Vector2 _moveInput;
    private bool _isMovingHorizontally => Mathf.Abs(_rigidbody2D.velocity.x) > Mathf.Epsilon;

    private void Awake() 
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update() 
    {
        Move();    
        FlipSprite();
    }

    private void Move()
    {
        Vector2 newVelocity = new Vector2(_moveInput.x * _moveSpeed, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = newVelocity;

        _animator.SetBool("isRunning", _isMovingHorizontally);
    }

    private void Jump()
    {
        LayerMask groundLayer = LayerMask.GetMask("Ground");
        if (!_collider2D.IsTouchingLayers(groundLayer))
            return;

        _rigidbody2D.velocity += new Vector2(0f, _jumpForce);
    }

    private void FlipSprite() 
    {
        if (!_isMovingHorizontally)
            return;

        transform.localScale = new Vector2(Mathf.Sign(_rigidbody2D.velocity.x), 1f);
    }

    private void OnMove(InputValue value) => _moveInput = value.Get<Vector2>();
    private void OnJump(InputValue value) 
    {
        if (value.isPressed)
        {
            Jump();
        }
    }
}
