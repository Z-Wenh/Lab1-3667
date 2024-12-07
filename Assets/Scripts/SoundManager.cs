using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager Instance;

    [SerializeField] private AudioSource _popAudio;

    void Awake() {
        if(Instance == null) {
            Instance = this;
        }
    }

    public void PlayBalloonPop(AudioClip audioClip, Transform targetTransform, float volume) {
        AudioSource audioSource = Instantiate(_popAudio, targetTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();

        float audioLength = audioSource.clip.length;
        Destroy(audioSource, audioLength);
    }
}
