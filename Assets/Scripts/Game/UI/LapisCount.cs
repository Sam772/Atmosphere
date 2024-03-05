using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LapisCount : MonoBehaviour {
    [SerializeField] private TMP_Text _lapisText;
    private int _count;

    void OnEnable() => Lapis.OnCollectedLapis += OnCollectibleCollected;
    void OnDisable() => Lapis.OnCollectedLapis -= OnCollectibleCollected;

    void OnCollectibleCollected() {
        _lapisText.text = "x" + (++_count).ToString();
    }
}
