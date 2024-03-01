using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lapis : MonoBehaviour {

    public int scoreValue = 10;
    public AudioClip collectSound;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            ScoreManager.instance.AddScore(scoreValue);
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            Destroy(gameObject);
        }
    }
}

