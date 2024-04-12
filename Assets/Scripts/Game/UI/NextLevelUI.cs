using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelUI : MonoBehaviour {

    void Start() {
        gameObject.SetActive(false);
    }

    public void ShowNextLevelUI() {
        gameObject.SetActive(true);
        //ToggleMenu();
    }

    public void CreateSaveData() {
        SerializationManager.Save("savefile", SaveData.Current);
    }

    public void ToggleMenu() {
        // Toggle the visibility of the in-game menu
        bool isVisible = !gameObject.activeSelf;
        gameObject.SetActive(isVisible);

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

    public void SelectLevelOne() => SceneManager.LoadScene("Level1");

    public void SelectLevelTwo() => SceneManager.LoadScene("Level2");
    
    public void SelectLevelThree() => SceneManager.LoadScene("Level3");

    public void SelectLevelFour() => SceneManager.LoadScene("Level4");

    public void SelectLevelFive() => SceneManager.LoadScene("Level5");
}
