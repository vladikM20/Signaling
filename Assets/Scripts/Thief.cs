using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Thief : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;
    private float _movementX;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _movementX = Input.GetAxis("Horizontal") * _speed;

        _rigidbody2D.velocity = new Vector2(_movementX, _rigidbody2D.velocity.y);
    }
}
