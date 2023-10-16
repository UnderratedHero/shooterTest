using UnityEngine;

public class PlayerConfig : MonoBehaviour
{
    [field: SerializeField] public float MaxHp { get; private set; } = 5f;

    [field: SerializeField] public float WalkSpeed { get; private set; } = 10f;

    [field: SerializeField] public float RightFlipAngle { get; private set; } 

    [field: SerializeField] public float LeftFlipAngle { get; private set; } 

    [field: SerializeField] public float UpFlipAngle { get; private set; }

    [field: SerializeField] public float DownFlipAngle { get; private set; }

}
