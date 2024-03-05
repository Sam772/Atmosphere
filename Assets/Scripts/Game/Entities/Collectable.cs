using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour {

    void Update() {
        transform.localRotation = Quaternion.Euler(transform.eulerAngles.x, Time.time * 100f, transform.eulerAngles.z);
    }
}
