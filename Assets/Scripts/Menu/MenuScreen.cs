using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : MonoBehaviour {
    protected Menu Menu { get; private set; }

    public void Setup(Menu menu) {
        Menu = menu;
    }

    public void Show() {
        OnShow();
        gameObject.SetActive(true);
    }

    public void Hide() {
        OnHide();
        gameObject.SetActive(false);
    }


    protected virtual void OnShow() {}
    protected virtual void OnHide() {}
}
