using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MenuScreen {

    [SerializeField] private AudioSource _audioSource;

    public IEnumerator PlayButtonSFX(Action callback) {
        _audioSource.Play();

        while (_audioSource.isPlaying) yield return null;

        callback?.Invoke();
    }

    public void NewGameButtonPressed() => StartCoroutine(PlayButtonSFX(() => NewGame()));
    
    public void NewGame() => SceneManager.LoadScene("Level1");

    public void ExitGameButtonPressed() => StartCoroutine(PlayButtonSFX(() => ExitGame()));
    
    public void ExitGame() => Application.Quit();

    new public void OnShow() {

    }

    new public void OnHide() {

    }
}
