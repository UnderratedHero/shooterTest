using UnityEngine;
using Unity.Netcode;

public class BulletErase : NetworkBehaviour
{
    [SerializeField] private BulletConfig _config;
    [SerializeField] private NetworkObject _networkObject;

    private void Start()
    {
        DestroyBulletServerRpc(_networkObject);
    }

    [ServerRpc(RequireOwnership = false)]
    private void DestroyBulletServerRpc(NetworkObjectReference bullet)
    {
        bullet.TryGet(out NetworkObject networkBullet);
        if (networkBullet == null)
        {
            return;
        }
        Destroy(networkBullet.gameObject, _config.BulletLifeTime);
    }
}
