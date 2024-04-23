using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroller : MonoBehaviour {
    [SerializeField] private RawImage _backgroundImage;
    [SerializeField] private float _x;
    [SerializeField] private float _y;

    void Update() {
        _backgroundImage.uvRect = new Rect(_backgroundImage.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _backgroundImage.uvRect.size);
    }
}
