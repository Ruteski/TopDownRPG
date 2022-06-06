using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _hole;
    [SerializeField] private Sprite _carrot;

    [SerializeField] private int _digAmount;// qtd de vezes de escavacao para criar o buraco

    private int _initialDigAmount;

    private void Start() {
        _initialDigAmount = _digAmount;
    }

    public void OnHit() {
        _digAmount--;

        if (_digAmount <= _initialDigAmount / 2) {
            _spriteRenderer.sprite = _hole;
        }

        //if (_digAmount <= 0) {
        //    _spriteRenderer.sprite = _carrot;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Dig")) {
            OnHit();
        }
    }

}
