using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private int maxHealth = 10;
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private float fireRate = 1f;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private Transform player;

    float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        RangedAttack();
    }

    //This function is used to have enemies both take and recieve damage. call change health with negative values to take damage, and positive values to heal damage.
    public void ChangeHealth(int healthLost)
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
            if (Time.time > nextFire)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                ProjectileController proj = projectile.GetComponent<ProjectileController>();

                if (proj != null)
                {
                    proj.targetName = "Player";
                    proj.target = player;
                }
                nextFire = Time.time + fireRate;
            }
        }
    }
}
