using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMixerManager : MonoBehaviour {
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Slider _musicSlider;

    void Start() {
        _volumeSlider.value = PlayerPrefs.GetFloat("SoundEffect");
        _musicSlider.value = PlayerPrefs.GetFloat("Music");
    }

    public void SetSoundEffectVolume(float volumeLevel) {
        _audioMixer.SetFloat("SoundEffect", volumeLevel);
        PlayerPrefs.SetFloat("SoundEffect", volumeLevel);
    }

    public  void SetMusisVolume(float volumeLevel) {
        _audioMixer.SetFloat("Music", volumeLevel);
        PlayerPrefs.SetFloat("Music", volumeLevel);
    }
}
