using Unity.Netcode;
using UnityEngine;

public class BulletSentry : NetworkBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _spawnPoint;
    private Rigidbody2D _currentBullet;

    public Rigidbody2D CreateBullet()
    {
        _currentBullet = Instantiate(_bullet, _spawnPoint.position, Quaternion.identity).GetComponent<Rigidbody2D>() ;
        CreateBulletServerRpc();
        return _currentBullet;
    }

    [ServerRpc]
    public void CreateBulletServerRpc()
    {
        _currentBullet.GetComponent<NetworkObject>().Spawn();
    }
}
