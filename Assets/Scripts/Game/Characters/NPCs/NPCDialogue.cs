using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour {
    private bool _hasInteracted = false;
    [SerializeField] private TMP_Text _npcDialogue;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && !_hasInteracted) {
            DisplayText(_npcDialogue.text);
            _hasInteracted = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            // Hide text or reset interaction state if needed
        }
    }

    private void DisplayText(string text) {
        // Display text on screen using UI system
        _npcDialogue.text = "I've never seen someone so oddly shaped, you look new here.";
    }
}

