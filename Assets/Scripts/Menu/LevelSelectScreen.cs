using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScreen : MenuScreen {

    public void SelectLevelOne() {
        SceneManager.LoadScene("Level1");
    }

    public void SelectLevelTwo() {
        SceneManager.LoadScene("Level2");
    }

    public void SelectLevelThree() {
        SceneManager.LoadScene("Level3");
    }

    public void SelectLevelFour() {
        SceneManager.LoadScene("Level4");
    }

    public void SelectLevelFive() {
        SceneManager.LoadScene("Level5");
    }

    new void OnShow() {

    }

    new void OnHide() {

    }
}
