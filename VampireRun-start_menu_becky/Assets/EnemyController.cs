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
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

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
