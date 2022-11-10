using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _rigidbody2D;

    private Vector2 _moveInput;

    private void Awake() 
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
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
    }

    private void FlipSprite() 
    {
        bool isMovingHorizontally = Mathf.Abs(_rigidbody2D.velocity.x) > Mathf.Epsilon;

        if (isMovingHorizontally)
        {
            transform.localScale = new Vector2(Mathf.Sign(_rigidbody2D.velocity.x), 1f);
        }
    }

    private void OnMove(InputValue value) => _moveInput = value.Get<Vector2>();

}
