using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    private int health;
    private int numOfHearts;
    private Player player;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    private void Start()
    {
        numOfHearts = player.maxHealth;
        health = player.health;
    }


    private void Update()
    {
        numOfHearts = player.maxHealth;
        health = player.health;
        Set_Hearts();
    }


    private void Set_Hearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Stops health from going above the number of heart
            if (health > numOfHearts)
            {
                health = numOfHearts;
            }

            // Controls whether or not heart is full or empty
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            // Controls Number of hearts
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }


}
