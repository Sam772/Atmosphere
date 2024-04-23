using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScreen : MenuScreen {

    [SerializeField] private SaveFileName _saveFileName;
    [SerializeField] private Text _playerName;

    protected override void OnShow() {
        base.OnShow();

        _playerName.text = "Welcome " + _saveFileName.saveFileName;
    }

    new void OnHide() {

    }
}
