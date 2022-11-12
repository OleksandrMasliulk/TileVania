using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private Animator _animator;

    private bool _isAlive = true; 
    public bool IsAlive => _isAlive;

    private void Awake() 
    {
        _animator = GetComponent<Animator>();    
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    private void Die() 
    {
        _isAlive = false;
        _animator.SetTrigger("Dying");
        gameObject.layer = 0;
    }
}
