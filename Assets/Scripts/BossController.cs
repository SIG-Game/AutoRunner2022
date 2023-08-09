using UnityEngine;

public class BossController : EnemyController
{
    [SerializeField]
    private HealthBar healthBar;
    
    public override void ChangeHealth(int healthLost)
    {
        base.ChangeHealth(healthLost);

        healthBar.SetHealth(currentHealth);

        if (currentHealth < 0) {  currentHealth = 0; }
        else if (currentHealth > maxHealth) {  currentHealth = maxHealth;  }
        /*
        currentHealth += healthLost;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0) 
        {  
            currentHealth = 0;
            Die();  
        }
        else if (currentHealth > maxHealth) {  currentHealth = maxHealth;  }
        */
    }
}
