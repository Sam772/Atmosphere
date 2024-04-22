using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiamondCount : MonoBehaviour {
    [SerializeField] private Text _diamondText;
    [SerializeField] private NextLevelUI _nextLevelUI;
    private int _count;

    void OnEnable() { 
        Diamond.OnCollectedDiamond += OnCollectibleCollected;
    }
    
    void OnDisable() {
        Diamond.OnCollectedDiamond -= OnCollectibleCollected;
    }

    void OnCollectibleCollected() {
        SaveData.Current.Diamonds += 1;
        _diamondText.text = "x" + SaveData.Current.Diamonds.ToString();
        _nextLevelUI.ShowNextLevelUI();
    }
}
