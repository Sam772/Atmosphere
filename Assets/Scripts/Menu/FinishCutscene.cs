using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishCutscene : MonoBehaviour {
    void Start() {
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene() {
        yield return new WaitForSeconds(17.5f);
        SceneManager.LoadScene("Level1");
    }

}
