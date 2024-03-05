using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiamondCount : MonoBehaviour {
    [SerializeField] private TMP_Text _diamondText;
    private int _count;

    void OnEnable() => Diamond.OnCollectedDiamond += OnCollectibleCollected;
    void OnDisable() => Diamond.OnCollectedDiamond -= OnCollectibleCollected;

    void OnCollectibleCollected() {
        _diamondText.text = "x" + (++_count).ToString();
    }
}
