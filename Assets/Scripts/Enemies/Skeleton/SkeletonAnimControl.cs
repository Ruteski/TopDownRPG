using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimControl : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _playerLayer;

    private Animator _animator;

    private void Start() {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnim(int value) {
        _animator.SetInteger("transition", value);
    }
    
    public void Attack() {
        Collider2D hit = Physics2D.OverlapCircle(_attackPoint.position, _radius, _playerLayer);

        if (hit != null) {
            //detectou colisao com o player
            print("bateu no player");
        } else {
            //
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(_attackPoint.position, _radius);
    }
}
