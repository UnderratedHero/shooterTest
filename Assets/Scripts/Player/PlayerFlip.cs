using Unity.Netcode;
using UnityEngine;

public class PlayerFlip : NetworkBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private PlayerConfig _config;

    private void Update()
    {
        if(!IsOwner)
        {
            return;
        }
        DirectionCheck();  
    }

    private void DirectionCheck()
    {
        if (_input.ShootDirection.x > 0 && _input.ShootDirection.y < 0.5 && _input.ShootDirection.y > -0.5)
        {
            Flip(_config.RightFlipAngle);
        }

        if (_input.ShootDirection.y > 0 && _input.ShootDirection.x < 0.5 && _input.ShootDirection.x > -0.5)
        {
            Flip(_config.UpFlipAngle);
        }

        if (_input.ShootDirection.x < 0 && _input.ShootDirection.y > -0.5 && _input.ShootDirection.y < 0.5)
        {
            Flip(_config.LeftFlipAngle);
        }

        if (_input.ShootDirection.y < 0 && _input.ShootDirection.x < 0.5 && _input.ShootDirection.x > -0.5)
        {
            Flip(_config.DownFlipAngle);
        }
    }

    private void Flip(float angle)
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
