using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameSettings : MonoBehaviour {

    [SerializeField] private Button _minimapToggle;
    [SerializeField] private RawImage _minimap;
    [SerializeField] private Image _minimapBackground;

    void Start() {
        gameObject.SetActive(false);
    }

    public void ToggleMap() {
        _minimap.gameObject.SetActive(!_minimap.gameObject.activeSelf);
        _minimapBackground.gameObject.SetActive(!_minimapBackground.gameObject.activeSelf);
    }

    void Update() {
        
    }
}
