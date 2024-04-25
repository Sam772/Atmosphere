using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
    [SerializeField] private Text _diamondsText;
    [SerializeField] private Text _lapisText;
    [SerializeField] private Text _livesText;
    [SerializeField] private InGameMenu _inGameMenu;

    void Start() {
        GetPlayerData();
        
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        
        _inGameMenu.gameObject.SetActive(false);
    }

    public void GetPlayerData() {
        SetLapisText("x" + SaveData.Current.Lapis.ToString());
        SetDiamondsText("x" + SaveData.Current.Diamonds.ToString());
        SetLivesText("x" + SaveData.Current.Lives.ToString());
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ToggleMenu();
        }
    }

    public void SetDiamondsText(string diamondsText) {
        _diamondsText.text = diamondsText;
    }
    
    public void SetLapisText(string lapisText) {
        _lapisText.text = lapisText;
    }

    public void SetLivesText(string livesText) {
        _livesText.text = livesText;
    }

    public void ToggleMenu() {
        bool isVisible = !_inGameMenu.gameObject.activeSelf;
        _inGameMenu.gameObject.SetActive(isVisible);
        _inGameMenu.HideSettings();

        if (isVisible) {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

}
