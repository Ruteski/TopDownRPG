using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _runSpeed;

    private Rigidbody2D _rb;
    private Vector2 _direction;
    private int _handlingObj = 1;
    private float _initialSpeed;
    private Items _playerItems;

    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _isDigging;
    private bool _isWatering;

    public bool isPaused;

    public Vector2 Direction { get => _direction; set => _direction = value; }
    public bool IsRunning { get => _isRunning; set => _isRunning = value; }
    public bool IsRolling { get => _isRolling; set => _isRolling = value; }
    public bool IsCutting { get => _isCutting; set => _isCutting = value; }
    public bool IsDigging { get => _isDigging; set => _isDigging = value; }
    public bool IsWatering { get => _isWatering; set => _isWatering = value; }
    public int HandlingObj { get => _handlingObj; set => _handlingObj = value; }

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _playerItems = GetComponent<Items>();
        _initialSpeed = _speed;
    }

    private void Update() {
        if (!isPaused) {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                _handlingObj = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                _handlingObj = 2;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3)) {
                _handlingObj = 3;
            }

            OnInput();
            OnRun();
            OnRolling();
            OnCutting();
            OnDiggin();
            OnWatering();
        }
    }

    private void FixedUpdate() {
        if (!isPaused) {
            OnMove();
        }
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

    private void OnCutting() {
        if (_handlingObj == 1) {
            if (Input.GetMouseButtonDown(0)) {
                _isCutting = true;
                _speed = 0;
            }

            if (Input.GetMouseButtonUp(0)) {
                _isCutting = false;
                _speed = _initialSpeed;
            }
        }
    }

    private void OnDiggin() {
        if (_handlingObj == 2) {
            if (Input.GetMouseButtonDown(0)) {
                _isDigging = true;
                _speed = 0;
            }

            if (Input.GetMouseButtonUp(0)) {
                _isDigging = false;
                _speed = _initialSpeed;
            }
        }
    }

    private void OnWatering() {
        if (_handlingObj == 3) {
            if (Input.GetMouseButtonDown(0) && _playerItems.TotalWater > 0) {
                _isWatering = true;
                _speed = 0;
                
            }

            if (Input.GetMouseButtonUp(0) || _playerItems.TotalWater <= 0) {
                _isWatering = false;
                _speed = _initialSpeed;
            }

            if (_isWatering) {
                _playerItems.TotalWater -= 0.01f;
            }
        }
    }

    #endregion
}
