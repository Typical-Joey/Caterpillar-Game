using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{

    public Slider slider;
    private Enemy enemy;


    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponentInParent<Enemy>();
        slider.maxValue = enemy.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = enemy.currentHealth;
    }
}
