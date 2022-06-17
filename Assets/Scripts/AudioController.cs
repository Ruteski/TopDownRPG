using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public static AudioController instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        } else {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(AudioClip audio) {
        _audioSource.clip = audio;
        _audioSource.Play();
    }
}
