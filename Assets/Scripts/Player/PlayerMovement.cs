using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private PlayerConfig _config;

    private void FixedUpdate()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        Move(_input.MovementDirection);
    }

    private void Move(Vector2 direction)
    {
        _rigidBody.MovePosition(_rigidBody.position + direction * _config.WalkSpeed * Time.fixedDeltaTime);
    }
}
