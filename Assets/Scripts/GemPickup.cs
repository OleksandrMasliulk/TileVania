using UnityEngine;

public class GemPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
            PickUp();
    }

    private void PickUp()
    {
        Destroy(this.gameObject);
    }
}
