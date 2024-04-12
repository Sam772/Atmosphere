using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiamondCount : MonoBehaviour {
    [SerializeField] private TMP_Text _diamondText;
    [SerializeField] private NextLevelUI _nextLevelUI;
    private int _count;

    void OnEnable() { 
        Diamond.OnCollectedDiamond += OnCollectibleCollected;
        SaveData.Current.Diamonds += 1;
    }
    
    void OnDisable() => Diamond.OnCollectedDiamond -= OnCollectibleCollected;

    void OnCollectibleCollected() {
        _diamondText.text = "x" + SaveData.Current.Diamonds.ToString();
        _nextLevelUI.ShowNextLevelUI();
    }
}
