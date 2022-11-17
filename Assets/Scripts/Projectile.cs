using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _flySpeed;

    private Rigidbody2D _rigidbody2D;

    private void Awake() 
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Construct(Transform shooter)
    {
        transform.localScale = new Vector2(Mathf.Sign(shooter.localScale.x) * transform.localScale.x, transform.localScale.y);
        _flySpeed *= Mathf.Sign(shooter.localScale.x);

        Destroy(this.gameObject, 3.5f);
    }

    private void FixedUpdate() 
    {
        Fly();
    }

    private void Fly()
    {
        _rigidbody2D.velocity = new Vector2(_flySpeed, 0f);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Enemy"))
            other.gameObject.GetComponent<Enemy>().Die();

        Destroy(this.gameObject);
    }
}
