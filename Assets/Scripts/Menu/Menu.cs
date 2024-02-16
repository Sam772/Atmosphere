using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    [SerializeField] private StartScreen _startScreen;
    private MenuScreen _currentScreen;

    private void Awake() {
        ShowStartScreen();
    }

    private void Start() {
        _startScreen.Setup(this);
    }

    public void ShowStartScreen() => ShowScreen(_startScreen);

    private void ShowScreen(MenuScreen screen) {
        if (_currentScreen == screen) return;

        if (screen != _startScreen) _startScreen.Hide();

        screen.Show();
        _currentScreen = screen;
    }
}
