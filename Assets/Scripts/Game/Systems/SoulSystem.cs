using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulSystem : MonoBehaviour {
    [SerializeField] private int _maxSouls = 3;
    [SerializeField] private float _hitValue = 1f;
    [SerializeField] private int _currentSouls;
    [SerializeField] private int _numOfSouls;
    [SerializeField] private Image[] _souls;
    [SerializeField] private Sprite _fullSoul;
    [SerializeField] private Sprite _emptySoul;

    void Start() {
        _currentSouls = _maxSouls;
    }

    void Update() {
        if (_currentSouls > _numOfSouls) {
            _currentSouls = _numOfSouls;
        }

        for (int i = 0; i < _souls.Length; i++) {
            if (i < _currentSouls) {
                _souls[i].sprite = _fullSoul;
            } else {
                _souls[i].sprite = _emptySoul;
            }

            if (i < _numOfSouls) {
                _souls[i].enabled = true;
            } else {
                _souls[i].enabled = false;
            }
        }
    }

    public void TakeDamage() {
        _currentSouls -= Mathf.CeilToInt(_hitValue);
        _currentSouls = Mathf.Clamp(_currentSouls, 0, _maxSouls);
        UpdateHealthUI();
        if (_currentSouls <= 0) {
            Die();
        }
    }

    void UpdateHealthUI() {
        Debug.Log("Current Health: " + _currentSouls);
    }

    void Die() {
        Debug.Log("Player died!");

        // Respawn the player
    }
}

