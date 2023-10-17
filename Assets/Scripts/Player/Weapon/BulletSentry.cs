using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSentry : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _spawnPoint;

    public Rigidbody2D CreateBullet()
    {
        return Instantiate(_bullet, _spawnPoint.position, Quaternion.identity).GetComponent<Rigidbody2D>();
    }
}
