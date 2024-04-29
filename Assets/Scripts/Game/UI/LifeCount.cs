using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour {
    [SerializeField] private Text _livesText;
    private int count;

    void OnEnable() {
        Life.OnCollectedLife += OnCollectibleCollected;
    }

    void OnDisable() {
        Life.OnCollectedLife -= OnCollectibleCollected;
    }

    void OnCollectibleCollected() {
        SaveData.Current.Lives += 1;
        _livesText.text = "x" + SaveData.Current.Lives.ToString();
    }
}
