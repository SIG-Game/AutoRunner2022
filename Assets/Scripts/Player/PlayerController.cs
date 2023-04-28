using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

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
    private ProjectileController proj;
    private Collider2D playerColl;

    public HashSet<Transform> enemyHash = new HashSet<Transform>();

    public int GetMaxHealth() => maxHealth;
    public int GetCurrentHealth() => currentHealth;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        targetPosition = rb2D.position;
        currentHealth = maxHealth;
        playerColl = this.GetComponent<Collider2D>();
        nextFire = Time.time;
    }

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

        if (rb2D.position == targetPosition && enemyHash.Count > 0) { RangedAttack(); }

        if (Input.GetKeyDown(KeyCode.H)) { Heal(20); }

        if (Input.GetKeyDown(KeyCode.Space)) { TakeDamage(20); }

        if (GetCurrentHealth() <= 0)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }

    private void FixedUpdate()
    {
        Vector2 newPosition = Vector2.MoveTowards(rb2D.position, targetPosition, movementSpeed);
        rb2D.MovePosition(newPosition);

        // TODO: Maybe set targetPosition to currentPosition when the player is stopped. Then, the player
        // won't continually try to reach an unreachable targetPosition when blocked by a collider.
    }

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

    private void RangedAttack()
    {
        if (Time.time > nextFire)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            proj = projectile.GetComponent<ProjectileController>();

            if (proj != null && enemyHash.Count > 0) { proj.SetUpProjectile(FindTargetEnemy(), playerColl); }

            nextFire = Time.time + fireRate;
        }
    }

    private Transform FindTargetEnemy()
    {
        Transform closeEnem = null;
        float distToClosestEnem = Mathf.Infinity,
              distToEnem = 0;

        foreach (Transform enem in enemyHash)
        {
            distToEnem = (enem.position - transform.position).sqrMagnitude;

            if (distToEnem < distToClosestEnem)
            {
                distToClosestEnem = distToEnem;
                closeEnem = enem;
            }
        }
        return closeEnem;
    }
}
