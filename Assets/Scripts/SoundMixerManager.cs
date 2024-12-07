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
        if(!PlayerPrefs.HasKey("SoundEffect")) {
            PlayerPrefs.SetFloat("SoundEffect", -30);
            LoadSound();
        }
        else {
            LoadSound();
        }
        
        if(!PlayerPrefs.HasKey("Music")) {
            PlayerPrefs.SetFloat("Music", -30);
            LoadMusic();
        }
        else {
            LoadMusic();
        }
    }

    public void SetSoundEffectVolume(float volumeLevel) {
        _audioMixer.SetFloat("SoundEffect", volumeLevel);
        PlayerPrefs.SetFloat("SoundEffect", volumeLevel);
    }

    public void SetMusisVolume(float volumeLevel) {
        _audioMixer.SetFloat("Music", volumeLevel);
        PlayerPrefs.SetFloat("Music", volumeLevel);
    }

    public void LoadSound() {
        _volumeSlider.value = PlayerPrefs.GetFloat("SoundEffect");
    }

    public void LoadMusic() {
        _musicSlider.value = PlayerPrefs.GetFloat("Music");
    }
}
