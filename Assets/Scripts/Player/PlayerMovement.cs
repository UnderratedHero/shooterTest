using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private PlayerConfig _config;

    private void FixedUpdate()
    {
        Move(_input.MovementDirection);
    }

    private void Move(Vector2 direction)
    {
        _rigidBody.MovePosition(_rigidBody.position + direction * _config.WalkSpeed * Time.fixedDeltaTime);
    }
}
