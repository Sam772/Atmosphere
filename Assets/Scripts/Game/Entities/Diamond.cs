using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour, IEntity {
    
    [SerializeField] private AudioClip _collectableSound;

    public void CollectableSFX() {
        AudioSource.PlayClipAtPoint(_collectableSound, transform.position);
    }

    // Collectable implementation   
}

