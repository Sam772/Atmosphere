using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {
    [SerializeField] private Transform _orientation;
    [SerializeField] private Transform _playerCharacter;
    [SerializeField] private float _rotationSpeed;

    void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = _orientation.forward * verticalInput + _orientation.right * horizontalInput;

        if (inputDir != Vector3.zero) {
            _playerCharacter.forward = Vector3.Slerp(_playerCharacter.forward, inputDir.normalized, Time.deltaTime * _rotationSpeed);
        }
    }
}
