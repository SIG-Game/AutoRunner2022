using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private int maxHealth = 100;
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private float fireRate = 1f;
    private float nextFire;

    [SerializeField]
    private HealthBar healthBar;
    [SerializeField]
    private GameObject projectile;
    private Rigidbody2D rb2D;
    private Vector2 targetPosition;
    private Transform playerPos;
    private ProjectileController proj;
    private Collider2D playerColl;

    public HashSet<Transform> enemyHash = new HashSet<Transform>();

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        targetPosition = rb2D.position;
        currentHealth = maxHealth;
        playerPos = this.GetComponent<Transform>();
        playerColl = this.GetComponent<Collider2D>();
        nextFire = Time.time;
    }

    public int GetMaxHealth() => maxHealth;
    public int GetCurrentHealth() => currentHealth;

    private void Update()
    {
        if (PauseController.Instance.GamePaused) { return; }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                targetPosition = Camera.main.ScreenToWorldPoint(touch.position);
            }
        }
        else if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (PlayerNotMoving() && enemyHash.Count > 0) { RangedAttack(); }

        if (Input.GetKeyDown(KeyCode.H)) { Heal(20); }

        if (Input.GetKeyDown(KeyCode.Space)) { TakeDamage(20); }
    }

    private void FixedUpdate()
    {
        Vector2 newPosition = Vector2.MoveTowards(rb2D.position, targetPosition, movementSpeed);
        rb2D.MovePosition(newPosition);

        // TODO: Maybe set targetPosition to currentPosition when the player is stopped. Then, the player
        // won't continually try to reach an unreachable targetPosition when blocked by a collider.
    }

    private void RangedAttack()
    {
        if (Time.time > nextFire)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            proj = projectile.GetComponent<ProjectileController>();

            if (proj != null)
            {
                proj.tName = ProjectileController.TargetName.Enemy;
                proj.target = FindTargetEnemy();
                proj.senderColl = playerColl;
            }
            nextFire = Time.time + fireRate;
        }
    }

    private Transform FindTargetEnemy()
    {
        Transform closeEnem = null;
        float distToCloseEnem = Mathf.Infinity,
              distToEnem = 0;

        foreach (Transform enem in enemyHash)
        {
            distToEnem = (enem.position - playerPos.position).sqrMagnitude;

            if (distToEnem < distToCloseEnem)
            {
                distToCloseEnem = distToEnem;
                closeEnem = enem;
            }
        }
        return closeEnem;
    }

    private bool PlayerNotMoving() => true;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth < 0) { currentHealth = 0; }
    }

    public void Heal(int heal)
    {
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);

        if (currentHealth > maxHealth) { currentHealth = maxHealth; }
    }
}
