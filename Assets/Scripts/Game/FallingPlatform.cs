using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {
    [SerializeField] private float _fallSpeed = 10f;
    [SerializeField] private float _respawnDelay = 2f;
    [SerializeField] private Vector3 _originalPosition;
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private Collider _collider;
    private bool isFalling = false;

    void Start() {
        _originalPosition = transform.position;
        _rigidBody.isKinematic = true;
        _rigidBody.useGravity = false;
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && !isFalling) {
            Fall();
        }
    }

    void Fall() {
        _rigidBody.useGravity = true;
        _rigidBody.isKinematic = false;

        _rigidBody.velocity = Vector3.down * _fallSpeed;
        isFalling = true;

        Invoke("Respawn", _respawnDelay);
    }

    void Respawn() {
        _rigidBody.isKinematic = true;
        _rigidBody.useGravity = false;
        _rigidBody.velocity = Vector3.zero;
        transform.position = _originalPosition;
        isFalling = false;
    }
}
