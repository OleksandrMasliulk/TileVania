using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player), typeof(Rigidbody2D), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Collider2D _feetCollider;
    [SerializeField] private Collider2D _bodyCollider;
    
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _climbSpeed;
    [SerializeField] private float _jumpForce;

    private Player _player;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private Vector2 _moveInput;
    private bool _isMovingHorizontally => Mathf.Abs(_moveInput.x) > Mathf.Epsilon;
    private bool _isMovingVertically => Mathf.Abs(_moveInput.y) > Mathf.Epsilon;

    private float _climbGravity = 0f;
    private float _defaultGravity;

    private void Awake() 
    {
        _player = GetComponent<Player>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start() 
    {
        _defaultGravity = _rigidbody2D.gravityScale;    
    }

    private void Update() 
    {
        if (!_player.IsAlive)
            return;

        FlipSprite();
    }

    private void FixedUpdate()
    {
        if (!_player.IsAlive)
            return;

        Move();
        Climb(); 
    }

    private void Move()
    {
        Vector2 newVelocity = new Vector2(_moveInput.x * _moveSpeed, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = newVelocity;

        _animator.SetBool("isRunning", _isMovingHorizontally);
    }

    private void Jump()
    {
        if (!_player.IsAlive)
            return;

        LayerMask groundLayer = LayerMask.GetMask("Ground");
        if (!_feetCollider.IsTouchingLayers(groundLayer))
            return;

        _rigidbody2D.velocity += new Vector2(0f, _jumpForce);
    }

    private void FlipSprite() 
    {
        if (!_isMovingHorizontally)
            return;

        transform.localScale = new Vector2(Mathf.Sign(_moveInput.x), 1f);
    }

    private void Climb()
    {
        LayerMask climbLayer = LayerMask.GetMask("Climbing");
        if (!_bodyCollider.IsTouchingLayers(climbLayer))
        {
            _rigidbody2D.gravityScale = _defaultGravity;
            _animator.SetBool("isClimbing", false);
            return;
        }

        _rigidbody2D.gravityScale = _climbGravity;
        Vector2 newVelocity = new Vector2(_rigidbody2D.velocity.x, _moveInput.y * _climbSpeed);
        _rigidbody2D.velocity = newVelocity;

        _animator.SetBool("isClimbing", _isMovingVertically);
    }

    private void OnMove(InputValue value) => _moveInput = value.Get<Vector2>();
    private void OnJump(InputValue value) 
    {
        if (value.isPressed)
            Jump();
    }
}
