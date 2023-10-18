using TMPro;
using UnityEngine;

public class WinUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _pickUpAmount;
    [SerializeField] private PickUpCount _pickUps;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void SetActiveUi()
    {
        gameObject.SetActive(true);
        _pickUpAmount.text = "PickUp's Collected: " + _pickUps.Amount;
    }
}
