using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveHealth : MonoBehaviour
{
    [SerializeField] private int Health_Amount = 1;
    [SerializeField] private int Food_Amount = 2;
    private Player player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.Get_Health(Health_Amount);
            player.growing.Get_Food(Food_Amount);
            Destroy(gameObject);
        }
    }

}
