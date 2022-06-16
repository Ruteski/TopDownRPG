using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimControl : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _playerLayer;

    private Animator _animator;
    private PlayerAnim _playerAnim;
    private SkeletonController _skeletonController;

    private void Start() {
        _animator = GetComponent<Animator>();
        _playerAnim = FindObjectOfType<PlayerAnim>();
        _skeletonController = GetComponentInParent<SkeletonController>();
    }

    public void PlayAnim(int value) {
        _animator.SetInteger("transition", value);
    }
    
    public void Attack() {
        if (!_skeletonController.IsDead) {
            Collider2D hit = Physics2D.OverlapCircle(_attackPoint.position, _radius, _playerLayer);

            if (hit != null) {
                //detectou colisao com o player
                _playerAnim.OnHit();
            }
        }
    }

    public void OnHit() {
        if (_skeletonController.Health <= 0) {
            _skeletonController.IsDead = true;
            _animator.SetTrigger("isDeath");
            Destroy(_skeletonController.gameObject, 0.84f);
        } else {
            _animator.SetTrigger("isHit");
            _skeletonController.Health--;

            _skeletonController.HealthBar.fillAmount = _skeletonController.Health / _skeletonController.TotalHealth;
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(_attackPoint.position, _radius);
    }
}
