using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    private bool _isAlive = true; 
    public bool IsAlive => _isAlive;

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
    }
}
