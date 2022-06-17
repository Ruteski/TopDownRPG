using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorSFX : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void PlaySFX(AudioClip clipe) {
        _audioSource.PlayOneShot(clipe);
    }
}
