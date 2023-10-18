using Unity.Netcode;
using UnityEngine;

public class PickUpSpawn : NetworkBehaviour
{
    [SerializeField] private GameObject _pickUp;
    [SerializeField] private float _spawnTimeMax;
    private float _spawnTime;
    private Vector2 _screenBounds;

    private void Start()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    private void Update()
    {
        _spawnTime -= Time.deltaTime;
        
        if(_spawnTime <= 0)
        {
            _spawnTime = _spawnTimeMax;
            PickUpSpawnServerRpc();
        }
    }

    [ServerRpc]
    private void PickUpSpawnServerRpc()
    {
        var spawnPoint = new Vector2(Random.Range(-_screenBounds.x,_screenBounds.x), Random.Range(-_screenBounds.y,_screenBounds.y));
        var pickUp = Instantiate(_pickUp, spawnPoint,Quaternion.identity);
        pickUp.GetComponent<NetworkObject>().Spawn(true);
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
    }
}
