using UnityEngine;

public class ProjController : MonoBehaviour
{
    [SerializeField]
    private int projDamage = 100;
    [SerializeField]
    private float projMoveSpeed = 7f;
    [SerializeField]
    private bool wantDeviation = true;
    [SerializeField]
    private float projDeviation = 1f;

    public string target = "null"; // Needs to be set on creation by creating object, "Player" to damage players, "Enemy" to damage enemies
    public Transform targetPos; // Needs to be set on creation by creating object

    private Rigidbody2D rb;
    private Vector2 moveDirect; // Movement Direction

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDirect = (targetPos.position - transform.position).normalized * projMoveSpeed;

        if (wantDeviation)
        {
            moveDirect.x = Random.Range(moveDirect.x - projDeviation, moveDirect.x + projDeviation);
            moveDirect.y = Random.Range(moveDirect.y - projDeviation, moveDirect.y + projDeviation);
        }
        rb.velocity = new Vector2(moveDirect.x, moveDirect.y);
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Rad2Deg * Mathf.Atan(moveDirect.y / moveDirect.x));
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D coll2D)
    {
        if (target == "null")
        {
            Debug.Log("Error: Projectile has no target name");
        }
        else if (target == "Player")
        {
            PlayerController player = coll2D.GetComponent<PlayerController>();

            if (player != null)
            {
                player.TakeDamage(projDamage);
                Destroy(gameObject);
            }
        }
        else if (target == "Enemy")
        {
            EnemyController enemy = coll2D.GetComponent<EnemyController>();

            if (enemy != null)
            {
                enemy.ChangeHealth(-1 * projDamage);
                Destroy(gameObject);
            }
        }
    }
}
