using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class YourStatsScreen : MenuScreen {

    [SerializeField] private TMP_Text _diamondStats;
    [SerializeField] private TMP_Text _lapisStats;

    protected override void OnShow() {
        base.OnShow();
        _diamondStats.text = "x " + SaveData.Current.Diamonds.ToString();
        _lapisStats.text = "x " + SaveData.Current.Lapis.ToString();
    }
}
