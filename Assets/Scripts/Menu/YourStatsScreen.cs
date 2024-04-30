using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class YourStatsScreen : MenuScreen {

    [SerializeField] private Text _diamondStats;
    [SerializeField] private Text _lapisStats;
    [SerializeField] private Text _livesText;
    [SerializeField] private Text _yourScore;

    protected override void OnShow() {
        base.OnShow();
        _diamondStats.text = "x " + SaveData.Current.Diamonds.ToString();
        _lapisStats.text = "x " + SaveData.Current.Lapis.ToString();
        _livesText.text = "x " + SaveData.Current.Lives.ToString();

        CalculateScore();
    }

    void CalculateScore() {
        int diamondScore = SaveData.Current.Diamonds * 100;
        int livesScore = SaveData.Current.Lives * 200;
        int lapisScore = SaveData.Current.Lapis;

        int total = diamondScore + livesScore + lapisScore;

        PlayerPrefs.SetInt("TotalScore", total);
        PlayerPrefs.Save();

        GetScore();
    }

    void GetScore() {
        int totalScore = PlayerPrefs.GetInt("TotalScore");
        _yourScore.text = totalScore.ToString();
    }
}
