using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour {
    [SerializeField] TMP_Text levelText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] private int _currentLevel;
    [SerializeField] private static float _currentScore;

    void Awake() {
        _currentLevel = SceneManager.GetActiveScene().buildIndex + 1;
        _currentScore = 0;
        DisplayScore();
        DisplayLevel();
    }
    
    public void AddPoints(float points) {
        _currentScore += points;
        DisplayScore();
        DisplayLevel();
    }

    public void DisplayScore() {
        scoreText.text = "Score: " + _currentScore;
    }
    
    public void DisplayLevel() {
        levelText.text = "Current Level: " + _currentLevel;  
    } 

    public int GetLevel() {
        return _currentLevel;
    }
    
    public void AdvanceNextLevel() {
        if(_currentLevel == 4) {
            return;
        }
        else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
