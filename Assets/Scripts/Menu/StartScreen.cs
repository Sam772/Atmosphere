using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MenuScreen {
    
    public void ExitGame() {
        Application.Quit();
    }

    public void PlayGame() {
        SceneManager.LoadScene("Level1");
    }

    new void OnShow() {

    }

    new void OnHide() {

    }
}
