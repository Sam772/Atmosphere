using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour, IPlatform {
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _moveSpeed = 5f;
    private bool _loop = true;
    private int currentWaypointIndex = 0;
    private bool movingForward = true;
    private Vector3 lastPosition;
    private Vector3 movementDelta;

    void Start() {
        lastPosition = transform.position;
    }

    void Update() {
        if (_wayPoints.Length == 0) return;

        Vector3 targetPosition = _wayPoints[currentWaypointIndex].position;
        float step = _moveSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        movementDelta = transform.position - lastPosition;
        lastPosition = transform.position;

        if (transform.position == targetPosition) {
            if (movingForward) {
                currentWaypointIndex++;
                if (currentWaypointIndex >= _wayPoints.Length) {
                    if (_loop) {
                        currentWaypointIndex = 0;
                    }
                    else {
                        movingForward = false;
                        currentWaypointIndex -= 2;
                    }
                }
            }
            else {
                currentWaypointIndex--;
                if (currentWaypointIndex < 0) {
                    if (_loop) {
                        currentWaypointIndex = 0;
                        movingForward = true;
                    }
                    else {
                        movingForward = true;
                        currentWaypointIndex = 1;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            other.transform.parent = null;
        }
    }

    public void Execute() {
        
    }
}
