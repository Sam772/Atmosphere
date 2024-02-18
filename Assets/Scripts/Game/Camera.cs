using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    private readonly float _smoothSpeed = 0.125f;
    private readonly float _rotationSpeed = 50f;

    void Update() {
        float mouseX = Input.GetAxis("Mouse X") * _rotationSpeed;
        Vector3 newRotation = transform.eulerAngles + new Vector3(0f, mouseX, 0f);
        transform.eulerAngles = newRotation;

        Vector3 desiredPosition = _target.position + _offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
        transform.position = smoothedPosition;

        transform.position = Vector3.Lerp(transform.position, _target.position, .02f);
        transform.rotation = Quaternion.Lerp(transform.rotation, _target.rotation, 0.1f);

        transform.LookAt(_target);
    }
}
