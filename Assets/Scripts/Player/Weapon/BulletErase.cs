using UnityEngine;

public class BulletErase : MonoBehaviour
{
    [SerializeField] private BulletConfig _config;

    private void Awake()
    {
        Destroy(gameObject, _config.BulletLifeTime);
    }
}
