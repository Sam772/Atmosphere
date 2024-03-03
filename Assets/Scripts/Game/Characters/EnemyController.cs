using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;
using VSCodeEditor;

public class EnemyController : MonoBehaviour, ICharacter {
    public float moveSpeed = 5f;
    public float attackRange = 2f;
    public float attackCooldown = 1f;
    public int attackDamage = 10;

    private Rigidbody rb;
    private bool canAttack = true;


    // ---------------------------

    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _player;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private LayerMask _whatIsPlayer;

    [SerializeField] private Vector3 _walkPoint;
    private bool _walkPointSet;
    [SerializeField] private float _walkPointRange;

    [SerializeField] private float _timeBetweenAttacks;
    private bool _alreadyAttacked;

    [SerializeField] private float _sightRange;
    [SerializeField] private float _attackRange;
    private bool _playerInSightRange;
    private bool _playerInAttackRange;

    [SerializeField] private GameObject _projectile;

    // ---------------------------

    void Awake() {
        _player = GameObject.Find("PlayerCharacter").transform;
        _agent = GetComponent<NavMeshAgent>();
    }

    void Start() {
        // rb = GetComponent<Rigidbody>();

        // if (_player == null)
        //     _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {

        _playerInSightRange = Physics.CheckSphere(transform.position, _sightRange, _whatIsPlayer);
        _playerInAttackRange = Physics.CheckSphere(transform.position, _attackRange, _whatIsPlayer);

        if (!_playerInSightRange && !_playerInAttackRange) Patrolling();
        if (_playerInSightRange && !_playerInAttackRange) ChasePlayer();
        if (_playerInAttackRange && _playerInSightRange) AttackPlayer();

        // Vector3 direction = (_player.position - transform.position).normalized;
        // rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);


        // if (Vector3.Distance(transform.position, _player.position) <= attackRange) {
        //     if (canAttack) {
        //         Attack();
        //         canAttack = false;
        //         Invoke("ResetAttackCooldown", attackCooldown);
        //     }
        // }
    }

    public void Patrolling() {
        if (!_walkPointSet) SearchWalkPoint();

        if (_walkPointSet) {
            _agent.SetDestination(_walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - _walkPoint;

        if (distanceToWalkPoint.magnitude < 1f) {
            _walkPointSet = false;
        }
    }

    public void SearchWalkPoint() {
        float randomZ = Random.Range(-_walkPointRange, _walkPointRange);
        float randomX = Random.Range(-_walkPointRange, _walkPointRange);

        _walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(_walkPoint, -transform.up, 2f, _whatIsGround)) {
            _walkPointSet = true;
        }
    }

    public void ChasePlayer() {
        _agent.SetDestination(_player.position);
    }

    public void AttackPlayer() {
        _agent.SetDestination(transform.position);

        transform.LookAt(_player);

        if (!_alreadyAttacked) {

            // Attack Code
            Debug.Log("I am attacking");

            _alreadyAttacked = true;
            Invoke(nameof(ResetAttack), _timeBetweenAttacks);
        }
    }

    public void ResetAttack() {
        _alreadyAttacked = false;
    }

    void Attack() {
        Debug.Log("Enemy attacks player!");
    }

    void ResetAttackCooldown() {
        canAttack = true;
    }

    public void Move() {

    }
}

