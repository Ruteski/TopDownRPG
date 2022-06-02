using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private List<Transform> _paths = new List<Transform>();
    [SerializeField] private float _speed;

    private int _index;
    private float _initialSpeed;
    private Animator _animator;

    private void Start() {
        _initialSpeed = _speed;
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (DialogControl.instance.IsShowing) {
            _speed = 0f;
            _animator.SetBool("isWalking", false);
        } else {
            _animator.SetBool("isWalking", true);
            _speed = _initialSpeed; 
        }

        transform.position = Vector2.MoveTowards(transform.position, _paths[_index].position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _paths[_index].position) < 0.1f) {
            if (_index < _paths.Count -1) {
                //_index++;
                _index = Random.Range(0, _paths.Count - 1);
            } else {
                _index = 0;
            }
        }

        Vector2 direction = _paths[_index].position - transform.position;

        if (direction.x > 0) {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (direction.x < 0) {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
