using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingController : MonoBehaviour
{
    [SerializeField] private int _percetage; // chance de pesca

    private Items _playerItems;
    private bool _detectingPlayer;

    private void Start() {
        //procura na cena toda um objeto com o nome de Items
        // só funciona pq so tenho 1 playerItems na cena toda
        _playerItems = FindObjectOfType<Items>();
    }

    private void Update() {
        if (_detectingPlayer && Input.GetKeyDown(KeyCode.E)) {
            OnCasting();
        }
    }

    private void OnCasting() {
        int randomValue = Random.Range(0, 100);

        if (randomValue <= _percetage) {
            //pegou peixe
            Debug.Log("pescou");
        } else {
            //falhou
            Debug.Log("nao pescou");
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
