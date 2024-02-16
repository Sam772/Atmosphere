using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private FileSelectScreen _fileSelectScreen;
    private MenuScreen _currentScreen;

    private void Awake() {
        ShowStartScreen();
    }

    private void Start() {
        _startScreen.Setup(this);
        _fileSelectScreen.Setup(this);
    }

    public void ShowStartScreen() => ShowScreen(_startScreen);
    public void ShowFileSelectScreen() => ShowScreen(_fileSelectScreen); 

    private void ShowScreen(MenuScreen screen) {
        if (_currentScreen == screen) return;

        if (screen != _startScreen) _startScreen.Hide();
        if (screen != _fileSelectScreen) _fileSelectScreen.Hide();

        screen.Show();
        _currentScreen = screen;
    }
}
