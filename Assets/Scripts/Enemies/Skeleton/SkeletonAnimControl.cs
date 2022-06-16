using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimControl : MonoBehaviour
{
    private Animator _animator;

    private void Start() {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnim(int value) {
        _animator.SetInteger("transition", value);
    }
}
