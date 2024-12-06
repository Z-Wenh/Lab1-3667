using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PersistentData : MonoBehaviour {
    [SerializeField] float playerScore;
    [SerializeField] string playerName;

    public static PersistentData Instance;

    void Awake() {
        if(Instance == null) {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else Destroy(gameObject);
    }

    void Start() {
        playerName = "";
        playerScore = 0;
    }

    public void SetName(string name) {
        playerName = name;
    }
    public void SetScore(float score) {
        playerScore = score;
    }

    public string GetName() {
        return playerName;
    }

    public float GetScore() {
        return playerScore;
    }
}
