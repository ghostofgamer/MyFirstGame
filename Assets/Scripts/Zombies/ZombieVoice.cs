using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieVoice : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void VoiceOff()
    {
        _audioSource.Stop();
    }
}
