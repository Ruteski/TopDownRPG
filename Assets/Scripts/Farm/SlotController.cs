using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _hole;
    [SerializeField] private Sprite _carrot;

    [Header("Settings")]
    [SerializeField] private int _digAmount;// qtd de vezes de escavacao para criar o buraco
    [Tooltip("Total de agua para para nascer uma cenoura")]
    [SerializeField] private int _waterAmount;// total de agua para para nascer uma cenoura
    [SerializeField] private bool _detecting;// se estou regando a o canteiro

    private Items _playerItems;

    private int _initialDigAmount;
    private float _currentWater;
    private bool _dugHole;//buraco cavado

    private void Start() {
        _initialDigAmount = _digAmount;
        _playerItems = FindObjectOfType<Items>();
    }

    private void Update() {
        if (_dugHole) {
            if (_detecting) {
                _currentWater += 0.01f;
            }

            //nasce uma cenoura
            if (_currentWater >= _waterAmount) {
                _spriteRenderer.sprite = _carrot;

                //coletar a cenoura
                if (Input.GetKeyDown(KeyCode.E)) {
                    _spriteRenderer.sprite = _hole;
                    _playerItems.Carrots++;
                    _currentWater = 0f;
                }
            }
        }
    }

    public void OnHit() {
        _digAmount--;

        if (_digAmount <= _initialDigAmount / 2) {
            _spriteRenderer.sprite = _hole;
            _dugHole = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Dig")) {
            OnHit();
        }

        if (collision.CompareTag("Watering")) {
            _detecting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Watering")) {
            _detecting = false;
        }
    }

}
