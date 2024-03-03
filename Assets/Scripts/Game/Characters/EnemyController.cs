using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public Transform player;
    public float moveSpeed = 5f;
    public float attackRange = 2f;
    public float attackCooldown = 1f;
    public int attackDamage = 10;

    private Rigidbody rb;
    private bool canAttack = true;

    void Start() {
        rb = GetComponent<Rigidbody>();

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {

        Vector3 direction = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);


        if (Vector3.Distance(transform.position, player.position) <= attackRange) {
            if (canAttack) {
                Attack();
                canAttack = false;
                Invoke("ResetAttackCooldown", attackCooldown);
            }
        }
    }

    void Attack() {
        Debug.Log("Enemy attacks player!");
    }

    void ResetAttackCooldown() {
        canAttack = true;
    }
}

