using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour {

    [SerializeField] private InGameSettings _inGameSettings;
    [SerializeField] private PlayerUI _playerUI;

    void Start() {
        gameObject.SetActive(false);
    }

    public void ShowSettings() {
        _inGameSettings.gameObject.SetActive(true);
    }

    public void HideSettings() {
        _inGameSettings.gameObject.SetActive(false);
    }

    public void BackToMainMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void CreateSaveData() {

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
            Debug.Log("Diamonds: " + SaveData.Current.Diamonds);
            Debug.Log("L2 Unlock State: " + SaveData.Current.Level2Unlocked);
            Debug.Log("L3 Unlock State: " + SaveData.Current.Level3Unlocked);

            _playerUI.SetLapisText("x" + SaveData.Current.Lapis.ToString());
            _playerUI.SetDiamondsText("x" + SaveData.Current.Diamonds.ToString());
        }
    }

    public void ExitGame() {
        Application.Quit();
    }
}
