using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    [SerializeField] private float _treeHealth;

    private Animator _animator;

    private void Start() {
        _animator = GetComponent<Animator>();
    }

    public void OnHit() {
        _treeHealth--;
        _animator.SetTrigger("isHit");

        if (_treeHealth <= 0) {
            //cria o tronco e instancia os drops(madeira)
            _animator.SetTrigger("cut");

        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Axe")) {
            OnHit();
        }
    }
}
