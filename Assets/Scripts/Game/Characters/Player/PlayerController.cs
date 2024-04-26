using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, ICharacter {
    private readonly float _moveSpeed = 10f;
    private readonly float _jumpForce = 12f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material _playerIdleMat;
    [SerializeField] private Material _playerRunMat;
    private bool _isGrounded;
    private int _consecutiveJumps = 0;
    private const int MaxConsecutiveJumps = 2;

    [SerializeField] private PlayerUI _playerUI;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _respawnValue;

    public int Diamonds => SaveData.Current.Diamonds;
    public int Lapis => SaveData.Current.Lapis;
    public int Lives => SaveData.Current.Lives;

    // Move health into here later

    void Start() {
        _rigidBody.freezeRotation = true;
    }

        void Update() {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, 0.1f, _groundLayer);
        Debug.Log("Is Grounded: " + _isGrounded);

        HandleMovement();
        HandleJumping();
        RotateToGround();
        ApplyGravity();

        if (gameObject.transform.position.y < -_respawnValue) {
            RespawnPlayer();
        }
    }

    void RespawnPlayer() {
        transform.position = _spawnPoint.position;
        
        SaveData.Current.Lives -= 1;
        _playerUI.SetLivesText("x" + SaveData.Current.Lives.ToString());

        if (SaveData.Current.Lives <= 0) {
            _playerUI.DisplayGameOver();
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

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
        if (_isGrounded) {
            _consecutiveJumps = 0;
        }

        if (_consecutiveJumps < MaxConsecutiveJumps && Input.GetButtonDown("Jump")) {
            _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _consecutiveJumps++;
            _isGrounded = false;
        }

        if (!_isGrounded && Physics.CheckSphere(_groundCheck.position, 0.1f, _groundLayer)) {
            _isGrounded = true;
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
