using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour {
    [SerializeField] private TMP_Text _npcDialogue;

    void Start() {
        _npcDialogue.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            DisplayText();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            // Hide text or reset interaction state if needed
            HideText();
        }
    }

    private void DisplayText() {
        // Display text on screen using UI system
        _npcDialogue.gameObject.SetActive(true);
    }

    private void HideText() {
        _npcDialogue.gameObject.SetActive(false);
    }
}

