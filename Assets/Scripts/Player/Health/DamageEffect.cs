using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    [SerializeField] private BulletConfig _config;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<DeathEffect>(out _))
        {
            DealDamage(collision);
        }
    }

    private void DealDamage(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerHealth>().Decrease(_config.Damage);
    }
}
