using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    #region Variables
    public int maxHealth = 5;
    public int health = 5;
    public float speed = 5;
    public float jumpForce = 5;

    [SerializeField] private float killFloor;
    [SerializeField] private Transform groudCheck;
    [SerializeField] private LayerMask groundObjects;
    [SerializeField] private bool facingRight = true;

    private Rigidbody2D rb;
    private float moveX;
    private float checkGroundRadius = 0.2f;
    private bool isGrounded = false;
    private bool isJumping = false;

    [HideInInspector]public PlayerAttack attack;
    [HideInInspector]public PlayerGrowing growing;
    #endregion


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        growing = GetComponent<PlayerGrowing>();
        attack = GetComponent<PlayerAttack>();
    }


    private void Update()// Better used for drawing and getting inputs
    {
        Get_Inputs();
        Animate();

        if(transform.position.y < killFloor)
        {
            Die();
        }

    }

    
    private void FixedUpdate()// Better for physics
    {
        isGrounded = Physics2D.OverlapCircle(groudCheck.position, checkGroundRadius, groundObjects);
        Move();
    }


    private void Get_Inputs()
    {
        moveX = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            isJumping = true;
        }
    }


    private void Animate()
    {
        if (moveX > 0 && !facingRight)
        {
            Flip_Player();
        } else if (moveX < 0 && facingRight)
        {
            Flip_Player();
        }
    }


    private void Move()
    {
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        if (isJumping)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        isJumping = false;
    }


    private void Flip_Player()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180f, 0);
    }


    public void Die()
    {
        health = 0;
        Debug.Log("PLayer Died");
        SceneManager.LoadScene("Prototype");
    }


    public void Get_Health(int healthGiven)
    {
        if (health != maxHealth)
        {
            health += healthGiven;
        }
    }


}
