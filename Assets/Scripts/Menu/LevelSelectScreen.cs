using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScreen : MenuScreen {

    [SerializeField] private AudioSource _audioSource;

    public IEnumerator PlayButtonSFX(Action callback) {
        _audioSource.Play();

        while (_audioSource.isPlaying) yield return null;

        callback?.Invoke();
    }

    public void SelectLevelOneButtonPressed() => StartCoroutine(PlayButtonSFX(() => SelectLevelOne()));

    public void SelectLevelOne() => SceneManager.LoadScene("Level1");

    public void SelectLevelTwoButtonPressed() => StartCoroutine(PlayButtonSFX(() => SelectLevelTwo()));

    public void SelectLevelTwo() => SceneManager.LoadScene("Level2");
    
    public void SelectLevelThreeButtonPressed() => StartCoroutine(PlayButtonSFX(() => SelectLevelThree()));

    public void SelectLevelThree() => SceneManager.LoadScene("Level3");
    
    public void SelectLevelFourButtonPressed() => StartCoroutine(PlayButtonSFX(() => SelectLevelFour()));

    public void SelectLevelFour() => SceneManager.LoadScene("Level4");
    
    public void SelectLevelFiveButtonPressed() => StartCoroutine(PlayButtonSFX(() => SelectLevelFive()));

    public void SelectLevelFive() => SceneManager.LoadScene("Level5");
    
    public new void OnShow() {

    }

    public new void OnHide() {

    }
}
