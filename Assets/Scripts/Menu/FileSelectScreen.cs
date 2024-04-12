using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;

public class FileSelectScreen : MenuScreen {
    public Button loadButtonPrefab;
    public string[] saveFiles;
    public Transform buttonContainer;
    public Scrollbar scrollbar;
    [SerializeField] private Menu _menu;
    public SaveFileName SaveFileName;
    
    public void GetLoadFiles() {
        if (!Directory.Exists(Application.persistentDataPath + "/saves/")) {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves/");
        }

        saveFiles = Directory.GetFiles(Application.persistentDataPath + "/saves/");

        Debug.Log("Loading all files: " + saveFiles);

        LoadFilesOnUI();
    }

    public void LoadFilesOnUI() {

        Vector3 buttonPosition = buttonContainer.position;
        float yOffset = -20f;

        // iterate through array of files and display on UI
        foreach (string filePath in saveFiles) {
            string fileName = Path.GetFileNameWithoutExtension(filePath);

            Button button = Instantiate(loadButtonPrefab, buttonContainer);

            button.transform.position = buttonPosition;

            buttonPosition += new Vector3(0f, yOffset, 0f);

            button.GetComponentInChildren<TMP_Text>().text = fileName;

            // Attach click event handler
            button.onClick.AddListener(() => ButtonPressed(button.GetComponentInChildren<TMP_Text>().text));

            Debug.Log(button.GetComponentInChildren<TMP_Text>().text);
        }
    }

    public void ButtonPressed(string filename) {
        SaveFileName.saveFileName = filename;
        SaveData.Current = (SaveData) SerializationManager.Load(Application.persistentDataPath + "/saves/" + filename + ".save");
        _menu.ShowMainMenuScreen();

        Debug.Log("Lapis: " + SaveData.Current.Lapis);
        Debug.Log("Diamonds: " + SaveData.Current.Diamonds);
        Debug.Log("Level 2 State:" + SaveData.Current.Level2Unlocked);
        Debug.Log("Level 3 State:" + SaveData.Current.Level3Unlocked);
    }

    void OnLoadButtonClick(string filePath) {
        // Implement logic to load the selected save file using the filePath
        Debug.Log("Loading file: " + filePath);
    }

    public new void OnShow() {

    }

    public new void OnHide() {

    }
}
