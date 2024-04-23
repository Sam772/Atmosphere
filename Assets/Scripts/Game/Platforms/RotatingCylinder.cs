using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCylinder : MonoBehaviour {
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _pushForce;

    void Update() {
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();

            if (playerRigidbody != null) {
                Vector3 pushDirection = -transform.up;
                playerRigidbody.AddForce(pushDirection * _pushForce, ForceMode.Force);
                other.transform.parent = transform;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            other.transform.parent = null;
        }
    }   
}

