using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float attackDelay = 0.5f;
    [SerializeField] private LayerMask playerLayer;

    private Transform t;
    private Player player;
    private float lastAttack;
    private bool PlayerInRange = false;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        t = transform;
    }


    private void FixedUpdate()
    {
        PlayerInRange = Physics2D.OverlapBox(t.position, t.localScale, 0, playerLayer);
        if(PlayerInRange && Time.time >= lastAttack + attackDelay)
        {
            Hit();
        }
    }

    private void Hit()
    {
        player.attack.Take_Damage(damage);
        lastAttack = Time.time;
    }
}
