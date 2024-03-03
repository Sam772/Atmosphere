using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lapis : MonoBehaviour, IEntity {

    [SerializeField] private int _scoreValue = 10;
    [SerializeField] private AudioClip _collectableSound;

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            ScoreManager.instance.AddScore(_scoreValue);
            CollectableSFX();
            Destroy(gameObject);
        }
    }

    public void CollectableSFX() {
        AudioSource.PlayClipAtPoint(_collectableSound, transform.position);
    }
}

