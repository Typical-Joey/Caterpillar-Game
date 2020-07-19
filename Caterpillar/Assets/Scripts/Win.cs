using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject particles;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(Instantiate(particles,transform.position, Quaternion.Euler(-90, 0, 0)), 3);
            Destroy(gameObject);
            Debug.Log("Player got to the goal!");
        }
    }
}
