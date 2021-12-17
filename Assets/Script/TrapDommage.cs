using UnityEngine;

public class TrapDommage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHealth.TakeDomage(10);

        }
    }

}
