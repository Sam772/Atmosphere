using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectScreen : MenuScreen {

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Image _levelTwoLock;
    [SerializeField] private Image _levelTwoUnlock;
    [SerializeField] private Image _levelThreeLock;
    [SerializeField] private Image _levelThreeUnlock;
    [SerializeField] private Image _levelFourLock;
    [SerializeField] private Image _levelFourUnlock;
    [SerializeField] private Image _levelFiveLock;
    [SerializeField] private Image _levelFiveUnlock;
    [SerializeField] private Text _errorText;

    public void SelectLevelOneButtonPressed() => StartCoroutine(PlayButtonSFX(() => SelectLevelOne()));

    public void SelectLevelOne() => SceneManager.LoadScene("Level1");

    public void SetLevelTwoButtonState() {
        if (SaveData.Current.Level2Unlocked == false) {
            //_levelTwoButton.gameObject.SetActive(false);
            _levelTwoLock.gameObject.SetActive(true);
            _levelTwoUnlock.gameObject.SetActive(false);
        } else {
           //_levelTwoButton.gameObject.SetActive(true);
            _levelTwoLock.gameObject.SetActive(false);
            _levelTwoUnlock.gameObject.SetActive(true);
        }
    }

    public void SelectLevelTwoButtonPressed() => StartCoroutine(PlayButtonSFX(() => SelectLevelTwo()));

    public void SelectLevelTwo() {
        if (SaveData.Current.Level2Unlocked == true) {
            SceneManager.LoadScene("Level2");
        } else {
            _errorText.text = "You have not unlocked Level 2 yet.";
        }
    }

    public void SetLevelThreeButtonState() {
        if (SaveData.Current.Level3Unlocked == false) {
            //_levelThreeButton.gameObject.SetActive(false);
            _levelThreeLock.gameObject.SetActive(true);
            _levelThreeUnlock.gameObject.SetActive(false);
        } else {
            //_levelThreeButton.gameObject.SetActive(true);
            _levelThreeLock.gameObject.SetActive(false);
            _levelThreeUnlock.gameObject.SetActive(true);
        }
    }

    public void SelectLevelThreeButtonPressed() => StartCoroutine(PlayButtonSFX(() => SelectLevelThree()));
    
    public void SelectLevelThree() {
        if (SaveData.Current.Level3Unlocked == true) {
            SceneManager.LoadScene("Level3");
        } else {
            _errorText.text = "You have not unlocked Level 3 yet.";
        }
    }

    public void SetLevelFourButtonState() {
        if (SaveData.Current.Level4Unlocked == false) {
            //_levelFourButton.gameObject.SetActive(false);
            _levelFourLock.gameObject.SetActive(true);
            _levelFourUnlock.gameObject.SetActive(false);
        } else {
            //_levelFourButton.gameObject.SetActive(true);
            _levelFourLock.gameObject.SetActive(false);
            _levelFourUnlock.gameObject.SetActive(true);
        }
    }
    
    public void SelectLevelFourButtonPressed() => StartCoroutine(PlayButtonSFX(() => SelectLevelFour()));

    public void SelectLevelFour() {
        if (SaveData.Current.Level4Unlocked == true) {
            SceneManager.LoadScene("Level4");
        } else {
            _errorText.text = "You have not unlocked Level 4 yet.";
        }
    }

    public void SetLevelFiveButtonState() {
        if (SaveData.Current.Level5Unlocked == false) {
            //_levelFiveButton.gameObject.SetActive(false);
            _levelFiveLock.gameObject.SetActive(true);
            _levelFiveUnlock.gameObject.SetActive(false);
        } else {
            //_levelFiveButton.gameObject.SetActive(true);
            _levelFiveLock.gameObject.SetActive(false);
            _levelFiveUnlock.gameObject.SetActive(true);
        }
    }
    
    public void SelectLevelFiveButtonPressed() => StartCoroutine(PlayButtonSFX(() => SelectLevelFive()));

    public void SelectLevelFive() {
        if (SaveData.Current.Level5Unlocked == true) {
            SceneManager.LoadScene("Level5");
        } else {
            _errorText.text = "You have not unlocked Level 5 yet.";
        }
    }

    public IEnumerator PlayButtonSFX(Action callback) {
        _audioSource.Play();

        while (_audioSource.isPlaying) yield return null;

        callback?.Invoke();
    }
    
    protected override void OnShow() {
        base.OnShow();
        _errorText.text = "";
        SetLevelTwoButtonState();
        SetLevelThreeButtonState();
        SetLevelFourButtonState();
        SetLevelFiveButtonState();
    }

    public new void OnHide() {

    }
}
