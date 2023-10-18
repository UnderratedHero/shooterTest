using Unity.Netcode;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    public void Die()
    {
       DieServerRpc(gameObject.GetComponent<NetworkObject>());
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
