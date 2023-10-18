using Unity.Netcode;
using UnityEngine;

public class PlayerInputUi : NetworkBehaviour
{
    private void Update()
    {
        if(!IsOwner)
        {
            gameObject.SetActive(false);
        }
    }
}
