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
        //SerializationManager.Save("savefile", SaveData.Current);

        SaveFileName saveFileNameHolder = FindObjectOfType<SaveFileName>();

        if (saveFileNameHolder != null) {
            string saveFileName = saveFileNameHolder.saveFileName;
            Debug.Log("Save file name: " + saveFileName);

            SerializationManager.Save(saveFileName, SaveData.Current);
            Debug.Log("File Saved: " + SaveData.Current);
            Debug.Log("Lapis: " + SaveData.Current.Lapis);
        }
    }

    public void LoadSaveData() {

        SaveFileName saveFileNameHolder = FindObjectOfType<SaveFileName>();

        if (saveFileNameHolder != null) {
            string saveFileName = saveFileNameHolder.saveFileName;
            Debug.Log("Save file name: " + saveFileName);

            SaveData.Current = (SaveData) SerializationManager.Load(Application.persistentDataPath + "/saves/" + saveFileName + ".save");
            Debug.Log("File Located: " + Application.persistentDataPath);

            Debug.Log("Lapis: " + SaveData.Current.Lapis);
            Debug.Log("L2 Unlock State: " + SaveData.Current.Level2Unlocked);
            Debug.Log("L3 Unlock State: " + SaveData.Current.Level3Unlocked);
        }
    }

    public void BackToMainMenu() {
        SceneManager.LoadScene("Menu");
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

    public void SelectLevelTwo() {
        SceneManager.LoadScene("Level2");
        SaveData.Current.Level2Unlocked = true;

        SaveFileName saveFileNameHolder = FindObjectOfType<SaveFileName>();

        if (saveFileNameHolder != null) {
            string saveFileName = saveFileNameHolder.saveFileName;
            Debug.Log("Save file name: " + saveFileName);

            SerializationManager.Save(saveFileName, SaveData.Current);
        }
    }
    
    public void SelectLevelThree() {
        SceneManager.LoadScene("Level3");
        SaveData.Current.Level3Unlocked = true;
    }

    public void SelectLevelFour() {
        SceneManager.LoadScene("Level4");
        SaveData.Current.Level4Unlocked = true;
    }

    public void SelectLevelFive() {
        SceneManager.LoadScene("Level5");
        SaveData.Current.Level5Unlocked = true;
    }
}
