using UnityEngine;
using Unity.Netcode;
public class Weapon : NetworkBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _spawnPosition;

    public void Shoot()
    {
        if(!IsOwner)
        {
            return;
        }
        SpawnBulletServerRpc(_spawnPosition.position, _spawnPosition.rotation);
    }

    [ServerRpc]
    private void SpawnBulletServerRpc(Vector2 position, Quaternion rotation)
    {
        var bullet = Instantiate(_bullet, position, rotation);
        bullet.GetComponent<NetworkObject>().Spawn(true);
    }
}
