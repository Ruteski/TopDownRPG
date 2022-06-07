using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    [SerializeField] private bool _detectingPlayer;
    [SerializeField] private float _waterValue;

    private Items _playerItems;

    private void Start() {
                       //procura na cena toda um objeto com o nome de Items
                       // só funciona pq so tenho 1 playerItems na cena toda
        _playerItems = FindObjectOfType<Items>();
    }

    private void Update() {
        if (_detectingPlayer && Input.GetKeyDown(KeyCode.E)) {
            _playerItems.WaterLimit(_waterValue);
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

