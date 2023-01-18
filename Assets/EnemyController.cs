using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private int maxHealth = 10; 
    [SerializeField]
    private int currentHealth;
    private Rigidbody2D rb2D;
    private float distanceToPlayer;
    [SerializeField]
    private PlayerController player;
    private Vector2 targetPosition;


       

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        targetPosition = rb2D.position;
        

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
        
    }

    void FixedUpdate()
    {
        if (IsWithinCamera())
        {
            targetPosition = player.transform.position;
            //move towards player
            Vector2 newPosition = Vector2.MoveTowards(rb2D.position, targetPosition, movementSpeed);
            rb2D.MovePosition(newPosition);
        }
    }

    //This function is used to have enemies both take and recieve damage. call change health with negative values to take damage, and positive values to heal damage.
    void ChangeHealth(int healthLost)
    {
        currentHealth += healthLost;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Object.Destroy(this.gameObject);
    }

    bool IsWithinCamera()
    {
        if (GetComponent<Renderer>().isVisible)
        {
            return true;
        }else return false;
    }

    void MeleeAttack()
    {
        if (IsWithinCamera())
        {

        }
    }

    void RangedAttack()
    {
        if (IsWithinCamera())
        {

        }
    }
}
