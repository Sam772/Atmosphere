using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {
    [SerializeField] private float _fallSpeed;
    [SerializeField] private float _respawnDelay = 2f;
    [SerializeField] private Vector3 _originalPosition;
    private bool _isFalling = false;

    public void Start() {
        _originalPosition = transform.position;
    }

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && !_isFalling) {
            Fall();
        }
    }

    public void Fall() {
        _isFalling = true;
        InvokeRepeating("MovePlatformDown", 0f, 0.02f);
        Invoke("Respawn", _respawnDelay);
    }

    public void MovePlatformDown() {
        transform.position += Vector3.down * _fallSpeed * Time.deltaTime;
    }

    public void Respawn() {
        CancelInvoke("MovePlatformDown");
        transform.position = _originalPosition;
        _isFalling = false;
    }
}
