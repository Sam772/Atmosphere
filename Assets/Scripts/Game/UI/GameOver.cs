using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    void Start() {
        gameObject.SetActive(false);
    }

    public void BackToMainMenu() {
        ResetLives();
        SceneManager.LoadScene("Menu");
    }

    public void ResetLives() {
        //SerializationManager.Save("savefile", SaveData.Current);

        SaveFileName saveFileNameHolder = FindObjectOfType<SaveFileName>();

        if (saveFileNameHolder != null) {
            string saveFileName = saveFileNameHolder.saveFileName;
            Debug.Log("Save file name: " + saveFileName);

            SaveData.Current.Lives = 3;

            SerializationManager.Save(saveFileName, SaveData.Current);
            Debug.Log("File Saved: " + SaveData.Current);
            Debug.Log("Lapis: " + SaveData.Current.Lapis);
        }
    }
}
