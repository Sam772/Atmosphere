using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LapisCount : MonoBehaviour {
    [SerializeField] private Text _lapisText;
    private int _count;

    void OnEnable() {
        Lapis.OnCollectedLapis += OnCollectibleCollected;
    }

    void OnDisable() {
        Lapis.OnCollectedLapis -= OnCollectibleCollected;
    }

    void OnCollectibleCollected() {
        SaveData.Current.Lapis += 1;
        _lapisText.text = "x" + SaveData.Current.Lapis.ToString();
    }
}
