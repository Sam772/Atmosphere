using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    [SerializeField] private PlayerController _player;
    [SerializeField] private Transform _respawnPosition;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            _player.UpdateRespawnPosition(_respawnPosition);
        }
    }
}
