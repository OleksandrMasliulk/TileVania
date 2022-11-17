using UnityEngine;

public class GemPickup : MonoBehaviour
{
    [SerializeField] private int _scoreValue;

    [SerializeField] private AudioClip _pickUpSfx;

    private bool _wasCollected = false;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
            PickUp();
    }

    private void PickUp()
    {
        if (_wasCollected)
            return;

        GameSession.Instance.AddScore(_scoreValue);
        AudioSource.PlayClipAtPoint(_pickUpSfx, Camera.main.transform.position, .1f);
        Destroy(this.gameObject);
    }
}
