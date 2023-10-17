using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    [SerializeField] private PlayerConfig _config;
    [SerializeField] private DeathEffect _deathSentry;
    private void Start()
    {
        Current = _config.MaxHp;
    }

    public int Current { get; private set; }

    public void Decrease(int value)
    {
        Current -= value;
        if (Current <= _config.MinHp)
        {
            Current = _config.MinHp;
            _deathSentry.Die();
        }
    }

    public void Increase(int value)
    {
        Current += value;
        if (Current >= _config.MaxHp)
        {
            Current = _config.MaxHp;
        }
    }

    public void Reload()
    {
        Current = _config.MaxHp;
    }
}

