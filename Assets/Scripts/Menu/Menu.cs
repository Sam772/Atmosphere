using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private FileSelectScreen _fileSelectScreen;
    [SerializeField] private MainMenuScreen _mainMenuScreen;
    [SerializeField] private SettingsScreen _settingsScreen;
    [SerializeField] private LevelSelectScreen _levelSelectScreen;
    private MenuScreen _currentScreen;

    private void Awake() {
        ShowStartScreen();
    }

    private void Start() {
        _startScreen.Setup(this);
        _fileSelectScreen.Setup(this);
        _mainMenuScreen.Setup(this);
        _settingsScreen.Setup(this);
        _levelSelectScreen.Setup(this);
    }

    public void ShowStartScreen() => ShowScreen(_startScreen);
    public void ShowFileSelectScreen() => ShowScreen(_fileSelectScreen);
    public void ShowMainMenuScreen() => ShowScreen(_mainMenuScreen);
    public void ShowSettingsScreen() => ShowScreen(_settingsScreen);
    public void ShowLevelSelectScreen() => ShowScreen(_levelSelectScreen);

    private void ShowScreen(MenuScreen screen) {
        if (_currentScreen == screen) return;

        if (screen != _startScreen) _startScreen.Hide();
        if (screen != _fileSelectScreen) _fileSelectScreen.Hide();
        if (screen != _mainMenuScreen) _mainMenuScreen.Hide();
        if (screen != _settingsScreen) _settingsScreen.Hide();
        if (screen != _levelSelectScreen) _levelSelectScreen.Hide();

        screen.Show();
        _currentScreen = screen;
    }
}
