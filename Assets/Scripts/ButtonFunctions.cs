using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour {
    [SerializeField] TMP_InputField playerNameInput;

    public void StartGame() {
        string name = playerNameInput.text;
        PersistentData.Instance.SetName(name);
        PersistentData.Instance.SetScore(0);
        SceneManager.LoadScene("Stage1");
    }   

    public void GoToMenu() {
        SceneManager.LoadScene("TitleScreen");
    }

    public void GoToInstruction() {
        SceneManager.LoadScene("InstructionScreen");
    }

    public void GoToScoreBoard() {
        SceneManager.LoadScene("EndScreen");
    }

    public void GoToSetting() {
        SceneManager.LoadScene("SettingScreen");
    }
}
