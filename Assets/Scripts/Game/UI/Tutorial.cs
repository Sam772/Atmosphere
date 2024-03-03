using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    [SerializeField] private TMP_Text _tutorialText;

    void Start() {
        StartCoroutine(SetMovementTutorialText("To move, use WASD or the arrow keys."));
    }

    IEnumerator SetMovementTutorialText(string tutorialText) {
        
        yield return new WaitForSeconds(1f);

        _tutorialText.text = tutorialText;

        yield return new WaitForSeconds(2f);

        _tutorialText.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f);

        StartCoroutine(SetJumpingTutorialText("To jump, press the spacebar."));
    }

    IEnumerator SetJumpingTutorialText(string tutorialText) {
        _tutorialText.text = tutorialText;

        _tutorialText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        _tutorialText.gameObject.SetActive(false);
    }

}
