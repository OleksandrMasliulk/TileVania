using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
public class PlayerGun : MonoBehaviour
{
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private Projectile _projectile;

    private Player _player;

    private void Awake() 
    {
        _player = GetComponent<Player>();
    }

    private void Shoot()
    {
        if (!_player.IsAlive)
            return;

        Projectile newProjectile = Instantiate(_projectile, _projectileSpawnPoint.position, Quaternion.identity);
        newProjectile.Construct(this.transform);
    }

    private void OnFire(InputValue value)
    {
        if (value.isPressed)
            Shoot();
    }
}
