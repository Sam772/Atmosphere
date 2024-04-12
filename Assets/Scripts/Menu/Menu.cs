using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private CreateFileScreen _createFileScreen;
    [SerializeField] private FileSelectScreen _fileSelectScreen;
    [SerializeField] private MainMenuScreen _mainMenuScreen;
    [SerializeField] private SettingsScreen _settingsScreen;
    [SerializeField] private LevelSelectScreen _levelSelectScreen;
    private MenuScreen _currentScreen;
    [SerializeField] private AudioSource _audioSource;

    private void Awake() {
        ShowInitialStartScreen();
    }

    private void Start() {
        _startScreen.Setup(this);
        _createFileScreen.Setup(this);
        _fileSelectScreen.Setup(this);
        _mainMenuScreen.Setup(this);
        _settingsScreen.Setup(this);
        _levelSelectScreen.Setup(this);
    }


    public IEnumerator PlayButtonSFX(Action callback) {
        _audioSource.Play();

        while (_audioSource.isPlaying) yield return null;

        callback?.Invoke();
    }

    public void ShowInitialStartScreen() => ShowScreen(_startScreen);
    public void ShowBackStartScreen() => StartCoroutine(PlayButtonSFX(() => ShowScreen(_startScreen)));
    public void ShowCreateFileScreen() => StartCoroutine(PlayButtonSFX(() => ShowScreen(_createFileScreen)));
    public void ShowFileSelectScreen() => StartCoroutine(PlayButtonSFX(() => ShowScreen(_fileSelectScreen)));
    public void ShowMainMenuScreen() => StartCoroutine(PlayButtonSFX(() => ShowScreen(_mainMenuScreen)));
    public void ShowSettingsScreen() => StartCoroutine(PlayButtonSFX(() => ShowScreen(_settingsScreen)));
    public void ShowLevelSelectScreen() => StartCoroutine(PlayButtonSFX(() => ShowScreen(_levelSelectScreen)));

    private void ShowScreen(MenuScreen screen) {
        if (_currentScreen == screen) return;

        if (screen != _startScreen) _startScreen.Hide();
        if (screen != _createFileScreen) _createFileScreen.Hide();
        if (screen != _fileSelectScreen) _fileSelectScreen.Hide();
        if (screen != _mainMenuScreen) _mainMenuScreen.Hide();
        if (screen != _settingsScreen) _settingsScreen.Hide();
        if (screen != _levelSelectScreen) _levelSelectScreen.Hide();

        screen.Show();
        _currentScreen = screen;
    }
}
