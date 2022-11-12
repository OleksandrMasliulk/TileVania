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
        if (other.gameObject.CompareTag("Hazards"))
        {
            Die();
        }
    }

    private void Die() 
    {
        _isAlive = false;
        _animator.SetTrigger("Dying");
        SetPlayerLayer(0);
    }

    private void SetPlayerLayer(int layer) 
    {
        Transform[] children = transform.GetComponentsInChildren<Transform>();
        foreach(Transform child in children)
        {
            child.gameObject.layer = layer;
        }
    }
}
