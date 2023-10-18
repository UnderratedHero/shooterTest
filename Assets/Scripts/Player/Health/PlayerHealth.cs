using System;
using UnityEngine;
using Unity.Netcode;

public class PlayerHealth : NetworkBehaviour, IHealth
{
    [SerializeField] private PlayerConfig _config;
    [SerializeField] private DeathEffect _deathSentry;
    public event Action OnDecreaseHealth;
    public event Action OnIncreaseHealth;

    private void Start()
    {
        Current =_config.MaxHp; 
    }
    public float Current { get; private set; }

    public void Decrease(float value)
    {
        Debug.Log("Current HP: " + (Current - 1));
        Current -= value;
        OnDecreaseHealth?.Invoke();
        if (Current <= _config.MinHp)
        {
            Current = _config.MinHp;
            _deathSentry.Die();
        }
    }

    public void Increase(float value)
    {
        Current += value;
        OnIncreaseHealth?.Invoke();
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

