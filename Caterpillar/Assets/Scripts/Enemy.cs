using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Variables
    public int maxHealth = 3;
    public int currentHealth;
    public int foodGiven = 1;

    [SerializeField] private int attackDamage = 1;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float attackDelay = 0.5f;
    [SerializeField] private Transform groundDetection;
    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask walls;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private GameObject damageParticles;

    private Rigidbody2D rb;
    private Player player;
    private bool facingRight = true;
    private bool playerInRange = false;
    private float attackRange = 0.5f;
    private float lastAttack;
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    void Start()
    {
        currentHealth = maxHealth;
    }


    private void FixedUpdate()
    {
        Movement();
        Attack();
    }


    private void Movement()
    {
        if (facingRight)
        {
            rb.velocity = Vector2.right * speed;
        }
        else if (!facingRight)
        {
            rb.velocity = Vector2.left * speed;
        }

        // Rotates enemy if it gets to an edge
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f, ground);
        RaycastHit2D wallInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, 0.1f, walls);
        if (groundInfo.collider == false || wallInfo.collider == true)
        {
            Flip();
        }
    }


    private void Attack()
    {
        playerInRange = Physics2D.OverlapCircle(transform.position, attackRange, playerLayer);

        if (playerInRange && Time.time > lastAttack + attackDelay)
        {
            player.attack.Take_Damage(attackDamage);
            lastAttack = Time.time;
        }
    }


    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
    }


    public void Take_Damage(int damage)
    {
        currentHealth -= damage;
        Destroy(Instantiate(damageParticles, transform.position, Quaternion.Euler(-90, 0, 0)), 1);

        if (currentHealth <= 0)
        {
            Die();
            Destroy(Instantiate(damageParticles, transform.position, Quaternion.Euler(-90, 0, 0)), 1);
        }
    }


    private void Die()
    {
        Destroy(gameObject);
        player.growing.Get_Food(foodGiven);
    }


}
