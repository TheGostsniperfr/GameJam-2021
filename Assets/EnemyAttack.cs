using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerHealth.TakeDomage(10);

    }
}
