using Unity.Netcode;
using UnityEngine;

public class PlayerConfig : NetworkBehaviour
{
    [field: SerializeField] public float MaxHp { get; private set; } = 100;

    [field: SerializeField] public float MinHp { get; private set; } = 0;

    [field: SerializeField] public float WalkSpeed { get; private set; } = 10f;

    [field: SerializeField] public float RightFlipAngle { get; private set; }

    [field: SerializeField] public float LeftFlipAngle { get; private set; }

    [field: SerializeField] public float UpFlipAngle { get; private set; }

    [field: SerializeField] public float DownFlipAngle { get; private set; }
}
