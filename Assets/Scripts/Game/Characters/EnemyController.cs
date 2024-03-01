using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public float moveSpeed = 5f;
    public float attackRange = 2f;
    public float attackCooldown = 1f; // Time between attacks
    public int attackDamage = 10;

    private Rigidbody rb;
    private bool canAttack = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // If player reference is not set, try to find it in the scene
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Move towards the player
        Vector3 direction = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);

        // Check if the player is within attack range
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            // If attack cooldown is over, attack the player
            if (canAttack)
            {
                Attack();
                canAttack = false;
                Invoke("ResetAttackCooldown", attackCooldown);
            }
        }
    }

    void Attack()
    {
        // Deal damage to the player or trigger some other action
        Debug.Log("Enemy attacks player!");
        // You can implement damage logic here
    }

    void ResetAttackCooldown()
    {
        canAttack = true;
    }
}

