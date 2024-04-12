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
        SerializationManager.Save("mysavefile", SaveData.Current);
        Debug.Log("File Saved: " + SaveData.Current);
        Debug.Log("Lapis: " + SaveData.Current.Lapis);
    }

    public void LoadSaveData() {
        SaveData.Current = (SaveData) SerializationManager.Load(Application.persistentDataPath + "/saves/mysavefile.save");
        Debug.Log("File Located: " + Application.persistentDataPath);
        Debug.Log("Lapis: " + SaveData.Current.Lapis);

        _playerUI.SetLapisText("x" + SaveData.Current.Lapis.ToString());
    }

    public void ExitGame() {
        Application.Quit();
    }
}
