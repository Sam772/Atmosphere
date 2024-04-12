using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFileName : MonoBehaviour {
    public string saveFileName;

    private void Awake() {
        if (FindObjectsOfType<SaveFileName>().Length > 1) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }
}
