using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSound : MonoBehaviour
{
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }


    public void PlaySound()
    {
        _audioSource.PlayOneShot(_audioSource.clip);
    }
}
