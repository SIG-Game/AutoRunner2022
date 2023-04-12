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
    private Rigidbody2D rb2D;
    private Vector2 targetPosition;

    float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        
        currentHealth = maxHealth;
        nextFire = Time.time;
    }

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
        targetPosition = rb2D.position;
    }

    // Update is called once per frame
    void Update()
    {
        RangedAttack();
    }

    void FixedUpdate()
    {
        rb2D.MovePosition(Vector2.MoveTowards(rb2D.position, targetPosition, movementSpeed));
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
                GameObject projGameObject = Instantiate(projectile, transform.position, Quaternion.identity);
                ProjectileController proj = projGameObject.GetComponent<ProjectileController>();

                if (proj != null)
                {
                    proj.tName = ProjectileController.TargetName.Player;
                    proj.target = player;
                }
                nextFire = Time.time + fireRate;
            }
        }
    }

    void TargetStill()
    {
        if (IsWithinCamera())
        {
            targetPosition = Vector2.zero;
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
            targetPosition = rb2D.position + (Vector2)(Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right * distance);

        }
    }
}
