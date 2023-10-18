using Unity.Netcode;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    [SerializeField] private NetworkObject _networkObject;

    public void Die()
    {
       DieServerRpc(_networkObject);
    }

    [ServerRpc(RequireOwnership = false)]
    private void  DieServerRpc(NetworkObjectReference playerNetworkRef)
    {
        playerNetworkRef.TryGet(out NetworkObject networkPlayer);
        if (networkPlayer == null)
        {
            return;
        }
        Destroy(networkPlayer.gameObject);
    }
}
