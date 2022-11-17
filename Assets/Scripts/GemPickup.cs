using UnityEngine;

public class GemPickup : MonoBehaviour
{
    [SerializeField] private AudioClip _pickUpSfx;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
            PickUp();
    }

    private void PickUp()
    {
        AudioSource.PlayClipAtPoint(_pickUpSfx, Camera.main.transform.position, .1f);
        Destroy(this.gameObject);
    }
}
