using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float moveSpeed = 1.0f; // Speed at which the player moves

    public HealthBar healthBar;

    
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        InvokeRepeating("takeDamageOverTime", 0.0f, 2.0f);
        
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

        // Move the game object in the direction of the arrow keys
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * moveSpeed;
        transform.position += (Vector3)movement;


        //Make camera follow player
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        
        
        

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
