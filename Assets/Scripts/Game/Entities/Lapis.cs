using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lapis : Collectable, IEntity {
    [SerializeField] private AudioClip _collectableSound;
    public static event Action OnCollectedLapis;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            OnCollectedLapis?.Invoke();
            // ScoreManager.instance.AddScore(_scoreValue);
            // CollectableSFX();
            Destroy(gameObject);
        }
    }

    public void CollectableSFX() {
        AudioSource.PlayClipAtPoint(_collectableSound, transform.position);
    }
}

