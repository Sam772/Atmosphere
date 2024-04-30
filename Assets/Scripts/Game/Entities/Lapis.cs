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
            CollectableSFX();
            Destroy(gameObject);
        }
    }

    public void CollectableSFX() {
        GameObject audioSourceObject = new GameObject("CollectableSound");
        AudioSource audioSource = audioSourceObject.AddComponent<AudioSource>();
        audioSource.volume = 10f;
        audioSource.PlayOneShot(_collectableSound);
        Destroy(audioSourceObject, _collectableSound.length);
    }
}

