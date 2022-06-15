using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Transicoes
 * 0 - idle
 * 1 - walking
 * 2 - run
 * 3 - roll
 * 4 - dig
 * 5 - watering
 */

public class PlayerAnim : MonoBehaviour
{

    private PlayerController _player;
    private Animator _animator;
    private CastingController _castingController;


    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
        _castingController = FindObjectOfType<CastingController>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        //OnRun();
    }

    #region Movement

    private void OnMove() {
        if (_player.Direction.sqrMagnitude > 0) {
            if (_player.IsRolling) {
                _animator.SetTrigger("isRoll");
            } else if (_player.IsRunning) {
                _animator.SetInteger("transition", 2);
            } else {
                _animator.SetInteger("transition", 1);
            }
        }

        if (_player.IsRolling) {
            _animator.SetTrigger("isRoll"); 
        }

        if (_player.Direction.sqrMagnitude <= 0) {
            _animator.SetInteger("transition", 0);
        }

        if (_player.Direction.x > 0) {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (_player.Direction.x < 0) {
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (_player.IsCutting) {
            _animator.SetInteger("transition", 3);
        }

        if (_player.IsDigging) {
            _animator.SetInteger("transition", 4);
        }

        if (_player.IsWatering) {
            _animator.SetInteger("transition", 5);
        }
    }

    //private void OnRun() {
    //    _animator.SetInteger("transition", 2);
    //}

    #endregion

    public void OnCastingStarted() {
        _animator.SetTrigger("isCasting");
        _player.isPaused = true;
    }

    public void OnCastingEnded() {
        _castingController.OnCasting();
        _player.isPaused = false;
    }

    public void OnHammeringStarted() {
        _animator.SetBool("isHammering", true);
    }

    public void OnHammeringEnded() {
        _animator.SetBool("isHammering", false);
    }
}
