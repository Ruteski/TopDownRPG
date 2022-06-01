using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _runSpeed;

    private Rigidbody2D _rb;
    private Vector2 _direction;

    private float _initialSpeed;
    private bool _isRunning;
    private bool _isRolling;

    public Vector2 Direction { get => _direction; set => _direction = value; }
    public bool IsRunning { get => _isRunning; set => _isRunning = value; }
    public bool IsRolling { get => _isRolling; set => _isRolling = value; }

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _initialSpeed = _speed;
    }

    private void Update() {
        OnInput();
        OnRun();
        OnRolling();
    }

    private void FixedUpdate() {
        OnMove();
    }

    #region Movement

    private void OnInput() {
        _direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void OnMove() {
        //_rb.position = _direction * _speed;
        _rb.MovePosition(_rb.position + _direction * _speed * Time.fixedDeltaTime);
    }

    private void OnRun() {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            _speed = _runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            _speed = _initialSpeed;
            _isRunning = false; 
        }
    }

    private void OnRolling() {
        if (Input.GetMouseButtonDown(1)) {
            _isRolling = true;
        }

        if (Input.GetMouseButtonUp(1)) {
            _isRolling = false;
        }
    }

    #endregion
}
