using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
public class PlayerGun : MonoBehaviour
{
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private GameObject _projectile;

    private Player _player;

    private void Awake() 
    {
        _player = GetComponent<Player>();
    }

    private void Shoot()
    {
        if (!_player.IsAlive)
            return;

        GameObject newProjectile = Instantiate(_projectile, _projectileSpawnPoint.position, Quaternion.identity);
    }

    private void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            Shoot();
        }
    }
}
