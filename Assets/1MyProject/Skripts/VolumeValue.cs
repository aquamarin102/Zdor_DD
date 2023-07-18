using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace Quest
{
    
    public class VolumeValue : MonoBehaviour
    {

        [SerializeField] private Slider slider;
        public AudioMixerGroup Mixer;

        public void ChangeVolume(float volume)
        {
            Mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
        }
    }
}