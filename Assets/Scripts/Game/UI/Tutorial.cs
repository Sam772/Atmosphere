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

        yield return new WaitForSeconds(2f);

        StartCoroutine(SetLapisCollectableTutorialText("You can collect Lapis by touching the blue objects."));
    }

    IEnumerator SetLapisCollectableTutorialText(string tutorialText) {
        _tutorialText.text = tutorialText;

        _tutorialText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        _tutorialText.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f);

        StartCoroutine(SetEnemyTutorialText1("There are green enemies around the map called, slimes."));
    }

    IEnumerator SetEnemyTutorialText1(string tutorialText) {
        _tutorialText.text = tutorialText;

        _tutorialText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        _tutorialText.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f);

        StartCoroutine(SetEnemyTutorialText2("They will try to push you off the map, be careful."));
    }

    IEnumerator SetEnemyTutorialText2(string tutorialText) {
        _tutorialText.text = tutorialText;

        _tutorialText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        _tutorialText.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f);

        StartCoroutine(SetDiamondCollectableTutorialText("You will need to collect a diamond at the end of the level to proceed."));
    }
    
    IEnumerator SetDiamondCollectableTutorialText(string tutorialText) {
        _tutorialText.text = tutorialText;

        _tutorialText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        _tutorialText.gameObject.SetActive(false);
    }
}
