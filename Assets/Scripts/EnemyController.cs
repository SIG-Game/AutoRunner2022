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
    private PlayerController player;

    private float nextFire;
    private bool inHash = false;
    private Transform playerTransform,
                      thisTransform;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        nextFire = Time.time;
        playerTransform = player.GetComponent<Transform>();
        thisTransform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        RangedAttack();

        UpdateHash();
    }

    private void UpdateHash()
    {
        if (player != null && IsWithinCamera())
        {
            player.enemyHash.Add(thisTransform);
            inHash = true;
        }
        else if (player != null && inHash)
        {
            player.enemyHash.Remove(thisTransform);
            inHash = false;
        }
    }

    // This function is used to have enemies both take and recieve damage.
    // Call change health with negative values to take damage, and positive values to heal damage.
    public void ChangeHealth(int healthLost)
    {
        currentHealth += healthLost;

        if (currentHealth <= 0) { Die(); }
    }

    void Die()
    {
        if (player != null)
        {
            player.enemyHash.Remove(thisTransform);
            inHash = false;
        }
        Object.Destroy(this.gameObject);
    }

    bool IsWithinCamera() => (GetComponent<Renderer>().isVisible) ? true : false;

    void MeleeAttack()
    {
        if (IsWithinCamera())
        {

        }
    }

    void RangedAttack()
    {
        if (IsWithinCamera() && Time.time > nextFire)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            ProjectileController proj = projectile.GetComponent<ProjectileController>();

            if (proj != null)
            {
                proj.target = playerTransform;
                proj.senderColl = null; // When Enemies have colliders,
                                        // TODO: Make a variable for Enemy's collider and put it here
            }
            nextFire = Time.time + fireRate;
        }
    }
}
