using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameSettings : MonoBehaviour {

    [SerializeField] private Button _minimapToggle;
    [SerializeField] private RawImage _minimap;
    [SerializeField] private Image _minimapBackground;
    [SerializeField] private AudioSource _audioSource;

    void Start() {
        gameObject.SetActive(false);
    }

    public IEnumerator PlayButtonSFX(Action callback) {
        _audioSource.Play();

        while (_audioSource.isPlaying) yield return null;

        callback?.Invoke();
    }

    public void ToggleMap() {
        _minimap.gameObject.SetActive(!_minimap.gameObject.activeSelf);
        _minimapBackground.gameObject.SetActive(!_minimapBackground.gameObject.activeSelf);
    }

    public void ShowToggleMap() => StartCoroutine(PlayButtonSFX(() => ToggleMap()));


    void Update() {
        
    }
}
