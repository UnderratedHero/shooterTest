using UnityEngine;
using Unity.Netcode;

public class BulletErase : NetworkBehaviour
{
    [SerializeField] private BulletConfig _config;

    private void Start()
    {
        DestroyBulletServerRpc(gameObject.GetComponent<NetworkObject>());
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
