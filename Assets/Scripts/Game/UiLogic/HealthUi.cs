using UnityEngine;
using UnityEngine.UI;

public class HealthUi : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private PlayerConfig _config;
    [SerializeField] private PlayerHealth _health;

    private void OnEnable()
    {
        _health.OnDecreaseHealth += UpdateHealthBar;
        _health.OnIncreaseHealth += UpdateHealthBar;
    }

    private void OnDisable()
    {
        _health.OnDecreaseHealth -= UpdateHealthBar;
        _health.OnIncreaseHealth -= UpdateHealthBar;
    }

    private void UpdateHealthBar()
    {
        _healthBar.fillAmount = _health.Current / _config.MaxHp;
    }
}
