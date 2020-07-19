using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float xMax;
    public float xMin;
    public float yMax;
    public float yMin;

    private Transform Player;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        float x = Mathf.Clamp(Player.position.x, xMin, xMax);
        float y = Mathf.Clamp(Player.position.y, yMin, yMax);

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
