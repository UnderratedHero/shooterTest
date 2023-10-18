using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUi : MonoBehaviour
{
    [SerializeField] private Button _createLobbyButton;
    [SerializeField] private Button _lobbyJoinButton;
    [SerializeField] private TMP_InputField _createLobbyName;
    [SerializeField] private TMP_InputField _joinLobbyCode;

    private void Awake()
    {
        _createLobbyButton.onClick.AddListener(() => {
            ShooterLobby.Instance.CreateLobby(_createLobbyName.text);
            });
        _lobbyJoinButton.onClick.AddListener(() => {
            ShooterLobby.Instance.JoinByCode(_joinLobbyCode.text);
        });
    }
}
