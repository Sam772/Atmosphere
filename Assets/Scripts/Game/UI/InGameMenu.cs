using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour {

    [SerializeField] private InGameSettings _inGameSettings;

    void Start() {
        gameObject.SetActive(false);
    }

    public void ShowSettings() {
        _inGameSettings.gameObject.SetActive(true);
    }

    public void BackToMainMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame() {
        Application.Quit();
    }
}
