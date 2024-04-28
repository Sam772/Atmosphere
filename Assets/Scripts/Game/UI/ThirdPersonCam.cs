using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamDone : MonoBehaviour {
    public Transform orientation;
    public Transform playerObj;
    public float rotationSpeed;

    public void Update() {

        // rotate player obj
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (inputDir != Vector3.zero)
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
    }
}
