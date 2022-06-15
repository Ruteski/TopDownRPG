using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    [SerializeField] private GameObject _houseCollider;
    [SerializeField] private SpriteRenderer _houseSprite;
    [SerializeField] private Transform _point;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _endColor;
    [SerializeField] private float _timeAmount; // qtd de tempo para finalizar a casa

    private PlayerController _player;
    private PlayerAnim _playerAnim;

    private bool _detectingPlayer;
    private float _timeCount;
    private bool _isBegining;

    private void Start() {
        //procura na cena toda um objeto com o nome de Items
        // só funciona pq so tenho 1 playerItems na cena toda
        _player = FindObjectOfType<PlayerController>();
        _playerAnim = _player.GetComponent<PlayerAnim>();
    }

    private void Update() {
        if (_detectingPlayer && Input.GetKeyDown(KeyCode.E)) {
            _isBegining = true;
            _playerAnim.OnHammeringStarted();
            _houseSprite.color = _startColor;
            _player.transform.position = _point.transform.position;
            _player.isPaused = true;
        }

        if (_isBegining) {
            _timeCount += Time.deltaTime;

            //casa é finalizada       
            if (_timeCount >= _timeAmount) {
                _playerAnim.OnHammeringEnded();
                _houseSprite.color = _endColor;
                _player.isPaused = false;
                _houseCollider.SetActive(true);
            } 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            _detectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            _detectingPlayer = false;
        }
    }
}
