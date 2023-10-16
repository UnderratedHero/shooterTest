using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private FixedJoystick _leftJoystick;
    [SerializeField] private FixedJoystick _rightJoystick;
    public Vector2 MovementDirection => _leftJoystick.Direction;
    public Vector2 ShootDirection => _rightJoystick.Direction;
}
