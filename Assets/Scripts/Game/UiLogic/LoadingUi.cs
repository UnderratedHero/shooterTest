using TMPro;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _lobbyName;
    [SerializeField] private TextMeshProUGUI _lobbyCode;
    [SerializeField] private Button _exitButton;
    private void Start()
    {
        Lobby lobby =  ShooterLobby.Instance.GetLobby();
        _lobbyName.text = "Lobby Name: " + lobby.Name;
        _lobbyCode.text = "Lobby Code: " + lobby.LobbyCode;
        _exitButton.onClick.AddListener(() => Application.Quit());
    }
}
