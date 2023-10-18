using UnityEngine;
using Unity.Netcode;

public class DamageEffect : NetworkBehaviour
{
    [SerializeField] private WeaponConfig _config;
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private string _tag;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!collision.gameObject.CompareTag(_tag))
        {
            return;
        }
        _health.Decrease(_config.Damage);
    }
}
