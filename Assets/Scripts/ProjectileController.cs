using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private int projDamage = 100;
    [SerializeField]
    private float projMoveSpeed = 7f;
    [SerializeField]
    private bool wantDeviation = true;
    [SerializeField]
    private float projDeviation = 1f;
    public TargetName tName; // "Player" to damage players, "Enemy" to damage enemies

    public enum TargetName { Player, Enemy };

    // These variables need to be set on creation of the instance
    [HideInInspector]
    public Transform target; // Transform of gameObject to target
    [HideInInspector]
    public Collider2D senderColl; // Collider of gameObject that is firing the proj

    void Start()
    {
        Rigidbody2D projRb = GetComponent<Rigidbody2D>();

        if (target != null)
        {
            Vector2 projVelocity = (target.position - transform.position).normalized * projMoveSpeed;

            if (wantDeviation)
            {
                projVelocity.x = Random.Range(projVelocity.x - projDeviation, projVelocity.x + projDeviation);
                projVelocity.y = Random.Range(projVelocity.y - projDeviation, projVelocity.y + projDeviation);
            }
            projRb.velocity = projVelocity;
            transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Rad2Deg * Mathf.Atan(projVelocity.y / projVelocity.x));
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D coll2D)
    {
        if (tName == TargetName.Player)
        {
            PlayerController player = coll2D.GetComponent<PlayerController>();

            if (player != null)
            {
                player.TakeDamage(projDamage);
            }
        }
        else if (tName == TargetName.Enemy)
        {
            EnemyController enemy = coll2D.GetComponent<EnemyController>();

            if (enemy != null)
            {
                enemy.ChangeHealth(-1 * projDamage);
            }
        }
        if (coll2D != senderColl && !coll2D.isTrigger)
        {
            Destroy(gameObject);
        }
    }
}
