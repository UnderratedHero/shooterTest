using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponConfig : MonoBehaviour
{
    [field: SerializeField] public float Damage { get; private set; } = 1f;
}
