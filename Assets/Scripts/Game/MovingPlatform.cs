using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _moveSpeed = 5f;
    private bool _loop = true;
    private int currentWaypointIndex = 0;
    private bool movingForward = true;

    void Update() {
        if (_wayPoints.Length == 0) return;

        Vector3 targetPosition = _wayPoints[currentWaypointIndex].position;
        float step = _moveSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

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
}
