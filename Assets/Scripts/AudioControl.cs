using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    [SerializeField] private AudioClip _bgmMusic;

    private AudioController _audioController;

    private void Start() {
        _audioController = FindObjectOfType<AudioController>();
        _audioController.PlayBGM(_bgmMusic);
    }
}
