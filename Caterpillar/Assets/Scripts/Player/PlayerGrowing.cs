using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;


public class PlayerGrowing : MonoBehaviour
{
    #region Variables
    enum State {original, stage1, stage2}
    public int growNumber = 5;
    public int foodPoints;

    private Player player;
    private Vector3 original_size;
    private Vector3 stage1_size = new Vector3(1.5f, 1.5f, 0);
    private Vector3 stage2_size = new Vector3(2f, 2f, 0);
    private State state = State.original;
    #endregion

    private void Awake()
    {
        player = GetComponent<Player>();
    }


    void Start()
    {
        original_size = transform.localScale;
    }


    private void FixedUpdate()
    {
        Scale_Size();
        Grow();

        if(foodPoints == growNumber)
        {
            player.health = player.maxHealth;
        }
    }


    void Scale_Size()
    {
        switch (state)
        {
            case State.original:
                transform.localScale = original_size;
                growNumber = 5;
                player.maxHealth = 3;
                break;

            case State.stage1:
                transform.localScale = stage1_size;
                growNumber = 7;
                player.maxHealth = 4;
                break;

            case State.stage2:
                transform.localScale = stage2_size;
                growNumber = 100;
                player.maxHealth = 5;
                break;
        }
    }


    void Grow()
    {
        if (foodPoints >= growNumber && state == State.original)
        {
            state = State.stage1;
            foodPoints = 0;
        }
        else if (foodPoints >= growNumber && state == State.stage1)
        {
            state = State.stage2;
            foodPoints = 0;
        }
    }


    public void Get_Food(int food)
    {
        foodPoints += food;
    }


}
