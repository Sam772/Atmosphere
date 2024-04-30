using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : Collectable, IEntity {
    
    public static event Action OnCollectedDiamond;
    [SerializeField] private AudioClip _collectableSound;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            OnCollectedDiamond?.Invoke();
            CollectableSFX();
            Destroy(gameObject);
        }
    }

    public void CollectableSFX() {
        GameObject audioSourceObject = new GameObject("CollectableSound");
        AudioSource audioSource = audioSourceObject.AddComponent<AudioSource>();
        audioSource.volume = 5f;
        audioSource.PlayOneShot(_collectableSound);
        Destroy(audioSourceObject, _collectableSound.length);
    }  
}

