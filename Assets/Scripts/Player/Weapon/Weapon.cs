using UnityEngine;
using Unity.Netcode;
public class Weapon : NetworkBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private BulletSentry _bulletSentry;
    [SerializeField] private WeaponConfig _config;
    private Vector2 _playerLastDirection = Vector2.right;

    private void Update()
    {
        if(_input.ShootDirection != Vector2.zero)
        {
            _playerLastDirection = _input.ShootDirection;
        }
    }

    public void Shoot()
    {
        if(!IsOwner)
        {
            return;
        }
        _bulletSentry.CreateBullet().AddForce(_config.ShootSpeed * _playerLastDirection, ForceMode2D.Impulse);
    }
}
