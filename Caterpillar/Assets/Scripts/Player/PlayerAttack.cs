using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 1;
    
    [SerializeField] private float attackRange = 0.4f;
    [SerializeField] private float attackDelay = 0.2f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private GameObject damageParticles;

    private float lastAttack;
    private Player player;
    private Collider2D[] enemiesInRange;


    private void Awake()
    {
        player = GetComponent<Player>();
    }


    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= attackDelay + lastAttack)
        {
            Attack();
        }
    }


    private void Attack()
    {
        enemiesInRange = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in enemiesInRange)
        {
            enemy.GetComponent<Enemy>().Take_Damage(damage);
        }
        lastAttack = Time.time;
    }


    public void Take_Damage(int damage)
    {
        player.health -= damage;
        Destroy(Instantiate(damageParticles, transform.position, Quaternion.Euler(-90, 0, 0)), 1);

        if (player.health <= 0)
        {
            player.Die();
            Destroy(Instantiate(damageParticles, transform.position, Quaternion.Euler(-90, 0, 0)), 1);
        }
    }


}
