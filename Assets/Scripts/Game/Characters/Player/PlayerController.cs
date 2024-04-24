using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, ICharacter {
    private readonly float _moveSpeed = 10f;
    private readonly float _jumpForce = 14f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material _playerIdleMat;
    [SerializeField] private Material _playerRunMat;
    private bool _isGrounded;

    public int Diamonds => SaveData.Current.Diamonds;
    public int Lapis => SaveData.Current.Lapis;
    public int Lives => SaveData.Current.Lives;

    // Move health into here later

    void Start() {
        _rigidBody.freezeRotation = true;
    }

        void Update() {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, 0.1f, _groundLayer);
        HandleMovement();
        HandleJumping();
        RotateToGround();
        ApplyGravity();
    }

    void HandleMovement() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        moveDirection = Quaternion.AngleAxis(_cameraTransform.rotation.eulerAngles.y, Vector3.up) * moveDirection;
        Vector3 moveVelocity = transform.TransformDirection(moveDirection) * _moveSpeed;
        _rigidBody.velocity = new Vector3(moveVelocity.x, _rigidBody.velocity.y, moveVelocity.z);
    }

    void HandleJumping() {
        if (_isGrounded && Input.GetButtonDown("Jump")) {
            _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }

    void RotateToGround() {
        if (_isGrounded) {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -Vector3.up, out hit, 1.0f, _groundLayer)) {
                Quaternion targetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            }
        }
    }

    void ApplyGravity() {
        if (_isGrounded) {
            _rigidBody.AddForce(Physics.gravity * _rigidBody.mass);
        }
    }

    public void Move() {
        // Move stuff into here later
    }

}
