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
    [Header("Attack Settings")]
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _enemyLayer;

    private PlayerController _player;
    private Animator _animator;
    private CastingController _castingController;
    private bool _isHitting;
    private float _recoveryTime = 1.5f;
    private float _timeCount;

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

        if (_isHitting) {
            _timeCount += Time.deltaTime;

            if (_timeCount >= _recoveryTime) {
                _isHitting = false;
                _timeCount = 0;
            }
        }
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

    #region Attack

    public void OnAttack() {
        Collider2D hit = Physics2D.OverlapCircle(_attackPoint.position, _radius, _enemyLayer);

        if (hit != null) {
            //atacou o inimigo
            hit.GetComponentInChildren<SkeletonAnimControl>().OnHit();
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(_attackPoint.position, _radius);
    }

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

    public void OnHit() {
        if (!_isHitting) {
            _animator.SetTrigger("isHit");
            _isHitting = true;
        }
        
    }
}
