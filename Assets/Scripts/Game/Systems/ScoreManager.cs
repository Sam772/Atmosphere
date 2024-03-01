using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager instance;

    private int score = 0;

    public void AddScore(int value) {
        score += value;
        Debug.Log("Score: " + score);
    }

    public int GetScore() {
        return score;
    }

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
}
