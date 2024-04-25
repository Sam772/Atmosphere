using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SettingsScreen : MenuScreen {

    public SaveFileName SaveFileName;

    public void DeleteSave() {
        string saveFileName = SaveFileName.saveFileName;
        Debug.Log("Save file name: " + saveFileName);
        SerializationManager.Delete(Application.persistentDataPath + "/saves/" + saveFileName + ".save");
    }

    new void OnShow() {

    }

    new void OnHide() {

    }
}
