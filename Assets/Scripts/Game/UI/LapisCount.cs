using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LapisCount : MonoBehaviour {
    [SerializeField] private Text _lapisText;
    [SerializeField] private Text _livesText;
    private int _count;

    void OnEnable() {
        Lapis.OnCollectedLapis += OnCollectibleCollected;
    }

    void OnDisable() {
        Lapis.OnCollectedLapis -= OnCollectibleCollected;
    }

    void OnCollectibleCollected() {
        SaveData.Current.Lapis += 1;

        if (SaveData.Current.Lapis > 99) {
            SaveData.Current.Lapis = 0;
            SaveData.Current.Lives += 1;
            _lapisText.text = "x" + SaveData.Current.Lapis.ToString();
            _livesText.text = "x" + SaveData.Current.Lives.ToString();
        }

        _lapisText.text = "x" + SaveData.Current.Lapis.ToString();
    }
}
