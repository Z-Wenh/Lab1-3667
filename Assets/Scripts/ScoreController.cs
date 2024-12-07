using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour {
    [SerializeField] TMP_Text levelText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] private int _currentLevel;
    [SerializeField] private int _numTargetRemaining;
    [SerializeField] private int _currentScore;
    [SerializeField] private int _oldScore;
    private const float TIMEDURATION = 2;
    private float _timeElapsed;

    void Awake() {
        _currentLevel = SceneManager.GetActiveScene().buildIndex;
        _numTargetRemaining = SceneManager.GetActiveScene().buildIndex;
        _currentScore = PersistentData.Instance.GetScore();
        _oldScore = _currentScore;
        DisplayScore();
        DisplayLevel();
    }
    
    void Update() {
        //Creating a timer of 2 seconds when no more balloon remaining and then load next scene
        if(_numTargetRemaining == 0) {
            _timeElapsed += Time.deltaTime;
            if(_timeElapsed >= TIMEDURATION) {
                AdvanceNextLevel();
            }
        }
    }
    public void AddPoints(int points) {
        _currentScore += points;
        PersistentData.Instance.SetScore(_currentScore);
        DisplayScore();
        DisplayLevel();
    }

    public void DisplayScore() {
        scoreText.text = "Score: " + _currentScore;
    }
    
    public void DisplayLevel() {
        levelText.text = "Player Name: " + PersistentData.Instance.GetName() + " - Current Level: " + _currentLevel;  
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
            _numTargetRemaining = SceneManager.GetActiveScene().buildIndex + 1;
            _oldScore = _currentScore;
        }
    }

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Prevent players from accumulating scores infinitely when they leave a balloon unpopped and reload the scene
        PersistentData.Instance.SetScore(_oldScore);
    }

    public void DescreaseRemainingTarget() {
        _numTargetRemaining--;
    }
}
