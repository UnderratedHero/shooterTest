using UnityEngine;

public class WeaponConfig : MonoBehaviour
{
    [field: SerializeField] public float ShootSpeed { get; private set; } = 10f;
}
