using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;

public class CreateFileScreen  : MenuScreen {

    public TMP_InputField saveName;

    public void OnSave() {
        SerializationManager.Save(saveName.text, SaveData.Current);
        Debug.Log("File Saved: " + SaveData.Current);
        Debug.Log("The save name of this file is: " + saveName.text);
    }

    public new void OnShow() {

    }

    public new void OnHide() {

    }
}
