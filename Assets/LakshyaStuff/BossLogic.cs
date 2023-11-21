using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLogic : MonoBehaviour
{
    public Transform player;
    public float visionRange = 10f;
    public float meleeRange = 3f;
    public float attackCooldown = 3f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;

    private float attackTimer;

    void Start()
    {
        attackTimer = attackCooldown;
    }

    void Update()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        if (distanceToPlayer <= meleeRange)
        {
            MeleeAttack();
        }
        else if (distanceToPlayer <= visionRange)
        {
            if (attackTimer <= 0)
            {
                Attack();
                attackTimer = attackCooldown;
            }
            else
            {
                attackTimer -= Time.deltaTime;
            }
        }
    }

    void Attack()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Vector3 direction = (player.position - transform.position).normalized;
        projectile.GetComponent<Rigidbody>().velocity = direction * projectileSpeed;
        Debug.Log("RANGEDDDDD");
    }

    void MeleeAttack()
    {
        //AAAAAAAAAAAAAAAAA
        Debug.Log("MELEEEEEEEE");
    }
}