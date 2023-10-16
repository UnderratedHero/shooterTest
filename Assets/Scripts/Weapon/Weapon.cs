using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private BulletSentry _sentry;
    [SerializeField] private WeaponConfig _config;
    private Vector2 _playerLastDirection;

    public void Shoot()
    {
       var currentBullet = _sentry.CreateBullet();
       currentBullet.AddForce(_config.ShootSpeed * _playerLastDirection, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if(_input.ShootDirection != Vector2.zero)
        {
            _playerLastDirection = _input.ShootDirection;
        }
    }
}
