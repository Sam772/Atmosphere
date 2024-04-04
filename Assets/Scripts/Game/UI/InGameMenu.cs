using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour {

    [SerializeField] private InGameSettings _inGameSettings;

    void Start() {
        this.gameObject.SetActive(false);
    }

    public void ShowSettings() {
        SceneManager.LoadScene("Menu");
    }

    public void BackToMainMenu() {
        _inGameSettings.gameObject.SetActive(true);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
