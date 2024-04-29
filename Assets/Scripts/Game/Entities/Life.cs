using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : Collectable, IEntity {
    [SerializeField] private AudioClip _collectableSound;
    public static event Action OnCollectedLife;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            OnCollectedLife?.Invoke();
            CollectableSFX();
            Destroy(gameObject);
        }
    }

    public void CollectableSFX() {
        AudioSource.PlayClipAtPoint(_collectableSound, transform.position);
    }
}
