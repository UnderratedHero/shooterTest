using Unity.Netcode;
using UnityEngine;

public class BulletSentry : NetworkBehaviour
{
    [SerializeField] private BulletConfig _config;
    [SerializeField] private Rigidbody2D _rigidBody;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        _rigidBody.AddForce(transform.right * _config.BulletSpeed, ForceMode2D.Impulse);
    }   
}
