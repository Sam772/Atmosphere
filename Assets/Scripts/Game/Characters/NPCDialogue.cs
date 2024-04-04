using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour {
    [SerializeField] private string _npcDialogue = "Hello, I am an NPC!";
    private bool _hasInteracted = false;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && !_hasInteracted) {
            DisplayText(_npcDialogue);
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
        Debug.Log(text);
    }
}

