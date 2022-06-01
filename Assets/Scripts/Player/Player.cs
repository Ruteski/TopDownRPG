using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rb;
    private Vector2 _direction;

    public Vector2 Direction { get => _direction; set => _direction = value; }

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        _direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate() {
        //_rb.position = _direction * _speed;
        _rb.MovePosition(_rb.position + _direction * _speed * Time.fixedDeltaTime);
    }
}
