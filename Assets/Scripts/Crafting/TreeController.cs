using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    [SerializeField] private float _treeHealth;
    [SerializeField] private GameObject _woodPrefab;
    [SerializeField] private int _totalWood;

    private Animator _animator;

    private void Start() {
        _animator = GetComponent<Animator>();

        _totalWood = Random.Range(1, 3);
    }

    public void OnHit() {
        _treeHealth--;
        _animator.SetTrigger("isHit");

        if (_treeHealth <= 0) {
            for (int i = 0; i < _totalWood; i++) {
                Instantiate(_woodPrefab, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f), transform.rotation);
            }

            _animator.SetTrigger("cut");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Axe")) {
            OnHit();
        }
    }
}
