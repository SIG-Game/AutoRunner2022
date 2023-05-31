using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private int projDamage = 50;
    [SerializeField]
    private float projMoveSpeed = 7f;
    [SerializeField]
    private bool wantDeviation = true;
    [SerializeField]
    private float projDeviation = 1f;

    public enum TargetName { Player, Enemy };
    public TargetName tName; // "Player" to damage players, "Enemy" to damage enemies

    private Transform target;
    private Collider2D senderColl;

    // Sets up the variables needed to be set on creation of the instance
    public void SetUpProjectile(Transform target, Collider2D senderColl)
    {
        this.target = target; // Transform of gameObject to target
        this.senderColl = senderColl; // Collider of gameObject that is firing the proj
    }

    private void Start()
    {
        Rigidbody2D projRb = GetComponent<Rigidbody2D>();

        if (target != null)
        {
            Vector2 projVelocity =
                (target.position - transform.position).normalized * projMoveSpeed;

            if (wantDeviation)
            {
                projVelocity.x = Random.Range(projVelocity.x - projDeviation,
                                            projVelocity.x + projDeviation);
                projVelocity.y = Random.Range(projVelocity.y - projDeviation,
                                            projVelocity.y + projDeviation);
            }
            projRb.velocity = projVelocity;
            transform.rotation = Quaternion.Euler(0f, 0f,
                Mathf.Rad2Deg * Mathf.Atan(projVelocity.y / projVelocity.x));
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D coll2D)
    {
        if (tName == TargetName.Player)
        {
            PlayerController player = coll2D.GetComponent<PlayerController>();

            if (player != null) {  player.TakeDamage(projDamage);  }
        }
        else if (tName == TargetName.Enemy)
        {
            EnemyController enemy = coll2D.GetComponent<EnemyController>();

            if (enemy != null) {  enemy.ChangeHealth(-1 * projDamage);  }
        }

        if (coll2D != senderColl && !coll2D.isTrigger) {  Destroy(gameObject);  }
    }
}