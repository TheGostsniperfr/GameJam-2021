using UnityEngine;

public class PickUpHealBonus : MonoBehaviour
{
    public PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            playerHealth.TakeHealth(10);

            //play sound
        }
    }
}
