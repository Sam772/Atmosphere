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
        AudioSource.PlayClipAtPoint(_collectableSound, transform.position);
    }  
}

