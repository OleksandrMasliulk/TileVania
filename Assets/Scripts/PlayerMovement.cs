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
    }
    
    private void Move()
    {
        Vector2 newVelocity = new Vector2(_moveInput.x * _moveSpeed, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = newVelocity;
    }

    private void OnMove(InputValue value) => _moveInput = value.Get<Vector2>();

}
