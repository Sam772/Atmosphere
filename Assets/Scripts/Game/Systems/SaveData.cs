using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[System.Serializable]
public class SaveData {
    private static SaveData _current;
    public static SaveData Current {
        get {
            if (_current == null) {
                _current = new SaveData();
            }
            return _current;
        }
        set {
            if (value != null) {
                _current = value;
            }
        }
    }
    public int Diamonds;
    public int Lapis;
    public int Lives = 3;
    public bool Level1Complete = false;
    public bool Level2Unlocked = false;
    public bool Level2Complete = false;
    public bool Level3Unlocked = false;
    public bool Level3Complete = false;
    public bool Level4Unlocked = false;
    public bool Level4Complete = false;
    public bool Level5Unlocked = false;
    public bool Level5Complete = false;
}
