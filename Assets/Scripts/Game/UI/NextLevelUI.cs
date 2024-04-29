using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevelUI : MonoBehaviour {

    [SerializeField] private Text _levelCompletionText;
    [SerializeField] private AudioSource _audioSource;

    void Start() {
        gameObject.SetActive(false);
    }

    public IEnumerator PlayButtonSFX(Action callback) {
        _audioSource.Play();

        while (_audioSource.isPlaying) yield return null;

        callback?.Invoke();
    }

    public void ShowNextLevelUI() {
        gameObject.SetActive(true);
        
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (SceneManager.GetActiveScene().name == "Level1") {
            Debug.Log("Current Scene Name: " + SceneManager.GetActiveScene().name);
            _levelCompletionText.text = SceneManager.GetActiveScene().name + " complete";
            SaveData.Current.Level1Complete = true;
            SaveData.Current.Level2Unlocked = true;
            OverwriteSaveData();
        } else if (SceneManager.GetActiveScene().name == "Level2") {
            Debug.Log("Current Scene Name: " + SceneManager.GetActiveScene().name);
            SaveData.Current.Level2Complete = true;
            SaveData.Current.Level3Unlocked = true;
            OverwriteSaveData();
        } else if (SceneManager.GetActiveScene().name == "Level3") {
            Debug.Log("Current Scene Name: " + SceneManager.GetActiveScene().name);
            SaveData.Current.Level3Complete = true;
            SaveData.Current.Level4Unlocked = true;
            OverwriteSaveData();
        } else if (SceneManager.GetActiveScene().name == "Level4") {
            Debug.Log("Current Scene Name: " + SceneManager.GetActiveScene().name);
            SaveData.Current.Level4Complete = true;
            SaveData.Current.Level5Unlocked = true;
            OverwriteSaveData();
        } else if (SceneManager.GetActiveScene().name == "Level5") {
            Debug.Log("Current Scene Name: " + SceneManager.GetActiveScene().name);
            SaveData.Current.Level5Complete = true;
            OverwriteSaveData();
        } else {
            Debug.Log("Current Scene Name: " + SceneManager.GetActiveScene().name);
        }
    }

    public void OverwriteSaveData() {
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

    public void ShowOverwriteSaveData() => StartCoroutine(PlayButtonSFX(() => OverwriteSaveData()));

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

    public void ShowLoadSaveData() => StartCoroutine(PlayButtonSFX(() => LoadSaveData()));

    public void BackToMainMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void ShowBackToMainMenu() => StartCoroutine(PlayButtonSFX(() => BackToMainMenu()));

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

    public void ShowSelectLevelTwo() => StartCoroutine(PlayButtonSFX(() => SelectLevelTwo()));
    
    public void SelectLevelThree() {
        SceneManager.LoadScene("Level3");
        SaveData.Current.Level3Unlocked = true;

        SaveFileName saveFileNameHolder = FindObjectOfType<SaveFileName>();

        if (saveFileNameHolder != null) {
            string saveFileName = saveFileNameHolder.saveFileName;
            Debug.Log("Save file name: " + saveFileName);

            SerializationManager.Save(saveFileName, SaveData.Current);
        }
    }

    public void ShowSelectLevelThree() => StartCoroutine(PlayButtonSFX(() => SelectLevelThree()));

    public void SelectLevelFour() {
        SceneManager.LoadScene("Level4");
        SaveData.Current.Level4Unlocked = true;

        SaveFileName saveFileNameHolder = FindObjectOfType<SaveFileName>();

        if (saveFileNameHolder != null) {
            string saveFileName = saveFileNameHolder.saveFileName;
            Debug.Log("Save file name: " + saveFileName);

            SerializationManager.Save(saveFileName, SaveData.Current);
        }
    }

    public void ShowSelectLevelFour() => StartCoroutine(PlayButtonSFX(() => SelectLevelFour()));

    public void SelectLevelFive() {
        SceneManager.LoadScene("Level5");
        SaveData.Current.Level5Unlocked = true;

        SaveFileName saveFileNameHolder = FindObjectOfType<SaveFileName>();

        if (saveFileNameHolder != null) {
            string saveFileName = saveFileNameHolder.saveFileName;
            Debug.Log("Save file name: " + saveFileName);

            SerializationManager.Save(saveFileName, SaveData.Current);
        }
    }

    public void ShowSelectLevelFive() => StartCoroutine(PlayButtonSFX(() => SelectLevelFive()));
}
