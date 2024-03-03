using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
    [SerializeField] private TMP_Text _diamondsText;
    [SerializeField] private TMP_Text _livesText;

    void Start() {
        SetDiamondsText("x0");
        SetLivesText("x3");
    }

    public void SetDiamondsText(string diamondsText) {
        _diamondsText.text = diamondsText;
    }

    public void SetLivesText(string livesText) {
        _livesText.text = livesText;
    }

}
