using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseResume : MonoBehaviour {

    [SerializeField] private GameObject _pauseMenu;

    void Awake() {
        if(_pauseMenu != null) {
            _pauseMenu.SetActive(false);
        }
    }
    public void PauseGame() {
        Time.timeScale = 0.0f;
        _pauseMenu.SetActive(true);
    }

    public void ResumeGame() {
        Time.timeScale = 1.0f;
        _pauseMenu.SetActive(false);
    }

    public void LoadTitleScreen() {
        SceneManager.LoadScene("TitleScreen");
        Time.timeScale = 1.0f;
    }
}
