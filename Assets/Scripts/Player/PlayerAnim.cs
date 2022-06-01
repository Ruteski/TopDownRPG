using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Transicoes
 * 0 - idle
 * 1 - walking
 * 2 - run
 */

public class PlayerAnim : MonoBehaviour
{

    private Player _player;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnRun();
    }


    #region Movement

    private void OnMove() {
        if (_player.Direction.sqrMagnitude > 0) {
            _animator.SetInteger("transition", 1);
        } else {
            _animator.SetInteger("transition", 0);
        }

        if (_player.Direction.x > 0) {
            transform.eulerAngles = new Vector2(0, 0);
        } else {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    private void OnRun() {
        if (_player.IsRunning) {
            _animator.SetInteger("transition", 2);
        }
    }

    #endregion
}
