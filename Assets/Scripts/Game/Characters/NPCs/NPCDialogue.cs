using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCDialogue : MonoBehaviour {
    [SerializeField] private Text _npcDialogue;
    [SerializeField] private Image _npcDialogueBox;
    [SerializeField] private Image _npcDialogueBoxBorderTop;
    [SerializeField] private Image _npcDialogueBoxBorderBottom;
    [SerializeField] private Image _npcDialogueBoxBorderLeft;
    [SerializeField] private Image _npcDialogueBoxBorderRight;

    void Start() {
        _npcDialogue.gameObject.SetActive(false);
        _npcDialogueBox.gameObject.SetActive(false);
        _npcDialogueBoxBorderTop.gameObject.SetActive(false);
        _npcDialogueBoxBorderBottom.gameObject.SetActive(false);
        _npcDialogueBoxBorderLeft.gameObject.SetActive(false);
        _npcDialogueBoxBorderRight.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            DisplayDialogue();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            HideDialogue();
        }
    }

    private void DisplayDialogue() {
        _npcDialogue.gameObject.SetActive(true);
        _npcDialogueBox.gameObject.SetActive(true);
        _npcDialogueBoxBorderTop.gameObject.SetActive(true);
        _npcDialogueBoxBorderBottom.gameObject.SetActive(true);
        _npcDialogueBoxBorderLeft.gameObject.SetActive(true);
        _npcDialogueBoxBorderRight.gameObject.SetActive(true);

        switch(gameObject.name) {
            case "NPCSpecial1":
                StartCoroutine(NPC1Special());
                break;
            case "NPCSpecial2":
                NPC2Special();
                break;
            default:
                Debug.Log("I am a regular NPC.");
                break;
        }
    }

    private void HideDialogue() {
        _npcDialogue.gameObject.SetActive(false);
        _npcDialogueBox.gameObject.SetActive(false);
        _npcDialogueBoxBorderTop.gameObject.SetActive(false);
        _npcDialogueBoxBorderBottom.gameObject.SetActive(false);
        _npcDialogueBoxBorderLeft.gameObject.SetActive(false);
        _npcDialogueBoxBorderRight.gameObject.SetActive(false);
    }

    private IEnumerator NPC1Special() {

        yield return new WaitForSeconds(1f);

        GameObject area3 = GameObject.Find("Area 3");

        if (area3 != null) {
            Transform hiddenTransform = area3.transform.Find("Entities/Hidden1");

            if (hiddenTransform != null) {
                GameObject hiddenObject = hiddenTransform.gameObject;
                hiddenObject.SetActive(true);
            }
        }
    }

    private void NPC2Special() {
    
    }
}

