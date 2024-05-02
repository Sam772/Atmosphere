using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectScreen : MenuScreen {

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Image _levelOneUnlock;
    [SerializeField] private Image _levelOneComplete;
    [SerializeField] private Image _levelTwoLock;
    [SerializeField] private Image _levelTwoUnlock;
    [SerializeField] private Image _levelTwoComplete;
    [SerializeField] private Image _levelThreeLock;
    [SerializeField] private Image _levelThreeUnlock;
    [SerializeField] private Image _levelThreeComplete;
    [SerializeField] private Image _levelFourLock;
    [SerializeField] private Image _levelFourUnlock;
    [SerializeField] private Image _levelFourComplete;
    [SerializeField] private Image _levelFiveLock;
    [SerializeField] private Image _levelFiveUnlock;
    [SerializeField] private Image _levelFiveComplete;
    [SerializeField] private Text _errorText;

    public void SelectLevelOneButtonPressed() => StartCoroutine(PlayButtonSFX(() => SelectLevelOne()));

    public void SetLevelOneButtonState() {
        if (SaveData.Current.Level1Complete == false) {
            _levelOneUnlock.gameObject.SetActive(true);
            _levelOneComplete.gameObject.SetActive(false);
        } else {
            _levelOneUnlock.gameObject.SetActive(false);
            _levelOneComplete.gameObject.SetActive(true);
        }
    }

    public void SelectLevelOne() {
        if (SaveData.Current.ViewedCutscene == false) {
            SaveData.Current.ViewedCutscene = true;
            SceneManager.LoadScene("Cutscene");
        } else {
            SceneManager.LoadScene("Level1");
        }
    }
    public void SetLevelTwoButtonState() {
        if (SaveData.Current.Level2Unlocked == true && SaveData.Current.Level2Complete == true) {
            //_levelTwoButton.gameObject.SetActive(false);
            _levelTwoComplete.gameObject.SetActive(true);
            _levelTwoLock.gameObject.SetActive(false);
            _levelTwoUnlock.gameObject.SetActive(false);
        } else if (SaveData.Current.Level2Unlocked == true && SaveData.Current.Level2Complete == false) {
           //_levelTwoButton.gameObject.SetActive(true);
            _levelTwoComplete.gameObject.SetActive(false);
            _levelTwoLock.gameObject.SetActive(false);
            _levelTwoUnlock.gameObject.SetActive(true);
        } else {
            _levelTwoComplete.gameObject.SetActive(false);
            _levelTwoLock.gameObject.SetActive(true);
            _levelTwoUnlock.gameObject.SetActive(false);
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
        if (SaveData.Current.Level3Unlocked == true && SaveData.Current.Level3Complete == true) {
            //_levelTwoButton.gameObject.SetActive(false);
            _levelThreeComplete.gameObject.SetActive(true);
            _levelThreeLock.gameObject.SetActive(false);
            _levelThreeUnlock.gameObject.SetActive(false);
        } else if (SaveData.Current.Level3Unlocked == true && SaveData.Current.Level3Complete == false) {
           //_levelTwoButton.gameObject.SetActive(true);
            _levelThreeComplete.gameObject.SetActive(false);
            _levelThreeLock.gameObject.SetActive(false);
            _levelThreeUnlock.gameObject.SetActive(true);
        } else {
            _levelThreeComplete.gameObject.SetActive(false);
            _levelThreeLock.gameObject.SetActive(true);
            _levelThreeUnlock.gameObject.SetActive(false);
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
        if (SaveData.Current.Level4Unlocked == true && SaveData.Current.Level4Complete == true) {
            //_levelTwoButton.gameObject.SetActive(false);
            _levelFourComplete.gameObject.SetActive(true);
            _levelFourLock.gameObject.SetActive(false);
            _levelFourUnlock.gameObject.SetActive(false);
        } else if (SaveData.Current.Level4Unlocked == true && SaveData.Current.Level4Complete == false) {
           //_levelTwoButton.gameObject.SetActive(true);
            _levelFourComplete.gameObject.SetActive(false);
            _levelFourLock.gameObject.SetActive(false);
            _levelFourUnlock.gameObject.SetActive(true);
        } else {
            _levelFourComplete.gameObject.SetActive(false);
            _levelFourLock.gameObject.SetActive(true);
            _levelFourUnlock.gameObject.SetActive(false);
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
        if (SaveData.Current.Level5Unlocked == true && SaveData.Current.Level5Complete == true) {
            //_levelTwoButton.gameObject.SetActive(false);
            _levelFiveComplete.gameObject.SetActive(true);
            _levelFiveLock.gameObject.SetActive(false);
            _levelFiveUnlock.gameObject.SetActive(false);
        } else if (SaveData.Current.Level5Unlocked == true && SaveData.Current.Level5Complete == false) {
           //_levelTwoButton.gameObject.SetActive(true);
            _levelFiveComplete.gameObject.SetActive(false);
            _levelFiveLock.gameObject.SetActive(false);
            _levelFiveUnlock.gameObject.SetActive(true);
        } else {
            _levelFiveComplete.gameObject.SetActive(false);
            _levelFiveLock.gameObject.SetActive(true);
            _levelFiveUnlock.gameObject.SetActive(false);
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
        SetLevelOneButtonState();
        SetLevelTwoButtonState();
        SetLevelThreeButtonState();
        SetLevelFourButtonState();
        SetLevelFiveButtonState();
    }

    public new void OnHide() {

    }
}
