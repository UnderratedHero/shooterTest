using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PickUpErase : MonoBehaviour
{
    [SerializeField] private string _tag;
    [SerializeField] private NetworkObject _networkObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(_tag))
        {
            DestroyPickUpServerRpc(_networkObject);
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void DestroyPickUpServerRpc(NetworkObjectReference pickUp)
    {
        pickUp.TryGet(out NetworkObject networkPickUp);
        if (networkPickUp == null)
        {
            return;
        }
        Destroy(networkPickUp.gameObject);
    }
}
