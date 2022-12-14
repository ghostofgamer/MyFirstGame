using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundShooter : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _shootClip;

    public void AudioShoot()
    {
        _audioSource.PlayOneShot(_shootClip);
    }
}
