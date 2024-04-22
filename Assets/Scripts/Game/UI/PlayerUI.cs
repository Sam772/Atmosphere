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
        SetDiamondsText("x0");
        SetLapisText("x0");
        SetLivesText("x3");
        
        _inGameMenu.gameObject.SetActive(false);
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
        // Toggle the visibility of the in-game menu
        bool isVisible = !_inGameMenu.gameObject.activeSelf;
        _inGameMenu.gameObject.SetActive(isVisible);
        _inGameMenu.HideSettings();

        // If the menu is visible, pause the game
        if (isVisible) {
            Time.timeScale = 0f; // Pause the game
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor
            Cursor.visible = true; // Make the cursor visible
        }
        else {
            Time.timeScale = 1f; // Resume the game
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
            Cursor.visible = false; // Hide the cursor
        }
    }

}
