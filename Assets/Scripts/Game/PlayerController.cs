using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private readonly float _moveSpeed = 100f;
    private readonly float _jumpForce = 50f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Rigidbody rb;
    private bool _isGrounded;

    void Start() {
        rb.freezeRotation = true;
    }

    void Update() {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, 0.1f, _groundLayer);

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        Vector3 moveVelocity = transform.TransformDirection(moveDirection) * _moveSpeed;
        rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);

        if (_isGrounded && Input.GetButtonDown("Jump")) {
            rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

        if (_isGrounded) {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -Vector3.up, out hit, 1.0f, _groundLayer)) {
                Quaternion targetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            }
        }

        if (_isGrounded) {
            rb.AddForce(Physics.gravity * rb.mass);
        }
    }
}
