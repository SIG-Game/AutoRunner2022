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
    private Transform playerTransform;
    private Rigidbody2D rb2D;
    private Vector2 targetPosition;

    private float nextFire;
    private bool inHash = false;
    private Transform playerTransform,
                      thisTransform;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    private void Awake() {
        currentHealth = maxHealth;
        nextFire = Time.time;
        playerTransform = player.GetComponent<Transform>();
        thisTransform = this.GetComponent<Transform>();
        rb2D = GetComponent<Rigidbody2D>();
        targetPosition = rb2D.position;
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
    void FixedUpdate()
    {
        TargetPlayer();
        rb2D.MovePosition(Vector2.MoveTowards(rb2D.position, targetPosition, movementSpeed));
    }

    //This function is used to have enemies both take and recieve damage. call change health with negative values to take damage, and positive values to heal damage.
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
            if (Time.time > nextFire)
            {
                GameObject projGameObject = Instantiate(projectile, transform.position, Quaternion.identity);
                ProjectileController proj = projGameObject.GetComponent<ProjectileController>();

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

    void TargetStill()
    {
        if (IsWithinCamera())
        {
            targetPosition = rb2D.position;
        }
    }

    void TargetPlayer()
    {
        if (IsWithinCamera())
        {
            targetPosition = player.position;
        }
    }

    void TargetLine(float distance, float angle)
    {
        if (IsWithinCamera())
        {
            targetPosition = rb2D.position + (Vector2)(Quaternion.Euler(0f, 0f, angle) * Vector3.right) * distance;
        }
    }
}
