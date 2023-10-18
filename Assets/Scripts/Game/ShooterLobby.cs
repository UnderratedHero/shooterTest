using System.Threading.Tasks;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;

public class ShooterLobby : MonoBehaviour
{
    [SerializeField] private int _maxLobbySize = 4;
    [SerializeField] private float _heartbeatTimerMax = 15f;
    private Lobby _joinedLobby;
    private float _heartbeatTimer;
    private const string KEY_RELAY_JOIN_CODE = "RelayJoinCode";


    private void Awake()
    {
        Instance= this;

        DontDestroyOnLoad(gameObject);

        InitializeUnityAuthentication();
    }

    public static ShooterLobby Instance{ get; private set; }

    private void Update()
    {
        HandleHeartbeat();
    }

    private async void InitializeUnityAuthentication()
    {
        if(UnityServices.State != ServicesInitializationState.Initialized)
        {
            InitializationOptions initializationOptions= new InitializationOptions();
            initializationOptions.SetProfile(Random.Range(0, 1000).ToString());
            await UnityServices.InitializeAsync(initializationOptions);
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }
    }

    private async Task<Allocation> AllocateRelay()
    {
        try
        {
            Allocation allocation = await RelayService.Instance.CreateAllocationAsync(_maxLobbySize - 1);
            return allocation;
        }
        catch (RelayServiceException e)
        {
            Debug.LogError(e.Message);
            return default;
        }
    }

    private async Task<string> GetRelayJoinCode(Allocation allocation)
    {
        try
        {
            string relayJoinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);
            return relayJoinCode;
        }
        catch(RelayServiceException e)
        {
            Debug.LogError(e.Message);
            return default;
        }  
    }


    private async Task<JoinAllocation> JoinRelay(string joinCode)
    {
        try
        {
            JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode);
            return joinAllocation;
        }
        catch (RelayServiceException e)
        {
            Debug.LogError(e.Message);
            return default;
        }
    }
    public async void CreateLobby(string lobbyName)
    {
        try
        {
            _joinedLobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, _maxLobbySize, new CreateLobbyOptions() { IsPrivate = false });

            Allocation allocation = await AllocateRelay();

            string relayJoinCode = await GetRelayJoinCode(allocation);

            await LobbyService.Instance.UpdateLobbyAsync(_joinedLobby.Id, new UpdateLobbyOptions
            {
                Data = new System.Collections.Generic.Dictionary<string, DataObject>
                {
                    {KEY_RELAY_JOIN_CODE, new DataObject(DataObject.VisibilityOptions.Member, relayJoinCode)}
                }
            });

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(new RelayServerData(allocation, "dtls"));

            NetworkManager.Singleton.StartHost();
            SceneLoader.LoadNetwork(SceneLoader.Scene.Loading);
        }
        catch(LobbyServiceException e)
        {
            Debug.Log(e);
        }
    }

    public async void JoinByCode(string lobbyCode)
    {
        try
        {
            _joinedLobby = await LobbyService.Instance.JoinLobbyByCodeAsync(lobbyCode);

            string relayJoinCode = _joinedLobby.Data[KEY_RELAY_JOIN_CODE].Value;

            JoinAllocation joinAllocation = await JoinRelay(relayJoinCode);

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(new RelayServerData(joinAllocation, "dtls"));

            NetworkManager.Singleton.StartClient();
        }
        catch(LobbyServiceException e)
        {
            Debug.Log(e);
        }
      
    }

    public Lobby GetLobby()
    {
        return _joinedLobby;
    }

    private void HandleHeartbeat()
    {
        if (IsLobbyHost())
        {
            _heartbeatTimer -= Time.deltaTime;
            if (_heartbeatTimer <= 0f)
            {
                _heartbeatTimer = _heartbeatTimerMax;

                LobbyService.Instance.SendHeartbeatPingAsync(_joinedLobby.Id);
            }
        }
    }

    private bool IsLobbyHost()
    {
        return _joinedLobby != null && _joinedLobby.HostId == AuthenticationService.Instance.PlayerId;
    }
}
