using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isInvincible = false;
    public float invicibilityFlashDelay = 0.2f;
    public float invincibilityTimeAfterHit = 3f;

    public SpriteRenderer graphics;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDomage(int domage)
    {

        if(currentHealth <= 0 ^ currentHealth-domage <= 0 ^ domage == -1)
        {
            //mort
            Debug.Log("perso est mort !");
        }
        else if (!isInvincible)
        {
            currentHealth -= domage;
            healthBar.SetHealth(currentHealth);
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }

    }

    public void TakeHealth(int heal)
    {
        if(currentHealth != 100)
        {
            if(currentHealth + heal >= 100)
            {
                currentHealth = 100;         
            }
            else
            {
                currentHealth += heal;
            }
            healthBar.SetHealth(currentHealth);

        }
    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invicibilityFlashDelay);

        }
    }
    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }
}
