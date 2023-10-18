using Unity.Services.Lobbies.Models;
using UnityEngine;
using Unity.Netcode;

public class ConnectionCheck : NetworkBehaviour
{
    [SerializeField] private string _objectTag;
    private int _objectIndex;

    void Update()
    {
        if(!IsServer)
        {
            return;
        }

        _objectIndex = GameObject.FindGameObjectsWithTag(_objectTag).Length;
        
        if(_objectIndex>1)
        {
            SceneLoader.LoadNetwork(SceneLoader.Scene.Game);
        }

    }
}
