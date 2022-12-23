using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    
    public HealthBar healthBar;

    
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);        
    }

    // Update is called once per frame
    void Update()
    {
        //Restore health to max when H is pressed
        if (Input.GetKeyDown(KeyCode.H))
        {
            heal(20);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeDamage(20);
        }

    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void heal(int heal)
    {
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);
    }


}
