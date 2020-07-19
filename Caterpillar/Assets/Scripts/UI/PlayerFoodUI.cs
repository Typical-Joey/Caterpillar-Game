using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFoodUI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private PlayerGrowing growing;


    private void Awake()
    {
        growing = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGrowing>();
    }


    private void Update()
    {
        slider.value = growing.foodPoints;
        slider.maxValue = growing.growNumber;
    }
}
