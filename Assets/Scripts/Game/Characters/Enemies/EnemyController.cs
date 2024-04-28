using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState {
    IDLE = 0,
    PATROLLING = 1,
    CHASINGPLAYER = 2,
    ATTACKINGPLAYER = 3
}

public class EnemyController : MonoBehaviour, ICharacter {
    [SerializeField] private float _moveSpeed;
    //[SerializeField] private float _attackRange;
    [SerializeField] private float _attackCooldown;
    [SerializeField] private float attackDamage;
    private bool canAttack = true;


    // Ai Stuff
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


    // new
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private EnemyState _enemyState;
    [SerializeField] private Transform[] _enemyWaypoints;
    private int _BisWalkingHash;
    private int _BisAttackingHash;

    void Awake() {
        _player = GameObject.Find("PlayerCharacter").transform;
        _agent = GetComponent<NavMeshAgent>();

        _enemyAnimator = GetComponent<Animator>();
        _BisWalkingHash = Animator.StringToHash("BisWalking");
        _BisAttackingHash = Animator.StringToHash("BisAttacking");
    }

    void Start() {
        if (_player == null) {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        _enemyState = EnemyState.IDLE;
    }

    void Update() {

        switch(_enemyState) {
            case EnemyState.IDLE:
                Idling();
                break;
            case EnemyState.PATROLLING:
                Patrolling();
                break;
            case EnemyState.CHASINGPLAYER:
                ChasePlayer();
                break;
            case EnemyState.ATTACKINGPLAYER:
                AttackPlayer();
                break;
            default:
                break;
        }


        // _playerInSightRange = Physics.CheckSphere(transform.position, _sightRange, _whatIsPlayer);
        // _playerInAttackRange = Physics.CheckSphere(transform.position, _attackRange, _whatIsPlayer);


        // if (!_playerInSightRange && !_playerInAttackRange) Patrolling();
        // if (_playerInSightRange && !_playerInAttackRange) ChasePlayer();
        // if (_playerInAttackRange && _playerInSightRange) AttackPlayer();

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

    void Idling() {
        _enemyState = EnemyState.PATROLLING;
    }

    public void Patrolling() {
        bool BisWalking = _enemyAnimator.GetBool(_BisWalkingHash);
        bool BisAttacking = _enemyAnimator.GetBool(_BisAttackingHash);
        bool forwardWalkAnim = Input.GetKey("b");
        bool attackAnim = Input.GetKey("n");

        if (!BisWalking && forwardWalkAnim) {
            _enemyAnimator.SetBool(_BisWalkingHash, true);
        }

        if (BisWalking && !forwardWalkAnim) {
            _enemyAnimator.SetBool(_BisWalkingHash, false);
        }

        if (!BisAttacking && forwardWalkAnim && attackAnim) {
            _enemyAnimator.SetBool(_BisAttackingHash, true);
        }

        if (BisAttacking && !forwardWalkAnim || !attackAnim) {
            _enemyAnimator.SetBool(_BisAttackingHash, false);
        }



        // if (!_walkPointSet) SearchWalkPoint();

        // if (_walkPointSet) {
        //     _agent.SetDestination(_walkPoint);
        // }

        // Vector3 distanceToWalkPoint = transform.position - _walkPoint;

        // if (distanceToWalkPoint.magnitude < 1f) {
        //     _walkPointSet = false;
        // }
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

        //Debug.Log("I can see the player.");
    }

    public void AttackPlayer() {
        
        // idk these two are causing the enemies to move?
        _agent.SetDestination(transform.position);

        transform.LookAt(_player);

        if (!_alreadyAttacked) {

            // Attack Code
            Debug.Log("I am going to attack.");

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

