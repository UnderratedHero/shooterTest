using TMPro;
using UnityEngine;

public class PickUpCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _pickUpAmount;
    [SerializeField] private string _tag;

    public int Amount { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_tag))
        {
            Amount++;
            _pickUpAmount.text = "PickUp's Collected: " + Amount;
        }
    }
}