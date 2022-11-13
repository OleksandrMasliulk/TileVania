using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Die()
    {
        Destroy(this.gameObject);
    }
}
