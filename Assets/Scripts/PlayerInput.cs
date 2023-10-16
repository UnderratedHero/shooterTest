using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;

    public Vector2 Direction => _joystick.Direction;
}
