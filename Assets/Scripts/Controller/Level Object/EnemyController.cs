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
    private float nextFire;

    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private PlayerController player;

    private Rigidbody2D rb2D;
    private Vector2 targetPosition;
    private SpriteRenderer spriteRenderer;
    private Collider2D enemyColl;
    private ProjectileController proj;
    private EnemySpawner spawner;

    public void SetPlayer(PlayerController player) { this.player = player; }

    public void SetSpawner(EnemySpawner spawner) { this.spawner = spawner; }

    // This function is used to have enemies both take and recieve damage.
    // Call change health with negative values to take damage, and positive values to heal damage.
    public void ChangeHealth(int healthLost)
    {
        currentHealth += healthLost;

        if (currentHealth <= 0) { Die(); }
    }

    public void Die()
    {
        if (player != null) { player.enemyHash.Remove(transform); }

        ScoreManager.Instance.EnemyFelled();
        Object.Destroy(this.gameObject);
    }

    private void Awake()
    {
        currentHealth = maxHealth;
        nextFire = Time.time;
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyColl = GetComponent<Collider2D>();
        targetPosition = rb2D.position;
    }

    // Update is called once per frame
    private void Update() { PeriodicRangedAttack(); }

    private void FixedUpdate()
    {
        TargetPlayer();
        rb2D.MovePosition(Vector2.MoveTowards(rb2D.position, targetPosition, movementSpeed));
    }

    private void OnDestroy()
    {
        if (spawner != null) { spawner.SpawnedEnemyDestroyed(); }
    }

    private void OnBecameVisible() {  player.enemyHash.Add(transform);  }

    private void OnBecameInvisible() {  player.enemyHash.Remove(transform);  }

    private bool IsWithinCamera() => spriteRenderer.isVisible;

    private void MeleeAttack()
    {
        if (IsWithinCamera()) { }
    }

    private void PeriodicRangedAttack()
    {
        if (IsWithinCamera() && player.transform != null && Time.time > nextFire)
        {
            proj = Instantiate(projectile, transform.position, Quaternion.identity)
                .GetComponent<ProjectileController>();

            if (proj != null) {  proj.SetUpProjectile(player.transform, enemyColl);  }

            nextFire = Time.time + fireRate;
        }
    }

    private void TargetStill() {
        if (IsWithinCamera()) { targetPosition = rb2D.position; }
    }

    private void TargetPlayer() {
        if (IsWithinCamera()) { targetPosition = player.transform.position; }
    }

    private void TargetLine(float distance, float angle)
    {
        if (IsWithinCamera())
        {
            targetPosition = rb2D.position
                + (Vector2)(Quaternion.Euler(0f, 0f, angle) * Vector3.right) * distance;
        }
    }
}
