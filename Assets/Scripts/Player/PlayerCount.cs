using UnityEngine;

public class PlayerCount : MonoBehaviour
{
    [SerializeField] private string _objectTag;
    [SerializeField] private WinUi _winUi;
    private int _objectIndex;

    void Update()
    {
        _objectIndex = GameObject.FindGameObjectsWithTag(_objectTag).Length;

        if (_objectIndex == 1 && SceneLoader.GetScene() == "Game")
        {
            _winUi.SetActiveUi();
            enabled = false;
        }
    }
}
