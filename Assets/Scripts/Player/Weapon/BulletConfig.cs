using UnityEngine;

public class BulletConfig : MonoBehaviour
{
    [field: SerializeField] public float BulletLifeTime { get; private set; } = 0.4f;

    [field: SerializeField] public float BulletSpeed { get; private set; } = 10f;
}
