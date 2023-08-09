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
    private int healthDecayDamage;
    [SerializeField]
    private float healthDecayTime;
    [SerializeField]
    private float fireRate = 1f;
    private float nextFire;
    private bool canPlayerMove;

    [SerializeField]
    private HealthBarManager healthBar;
    [SerializeField]
    private GameObject projectile;
    private Rigidbody2D rb2D;
    private Vector2 targetPosition;
    private ProjectileController proj;
    private Collider2D playerColl;

    public HashSet<Transform> enemyHash = new HashSet<Transform>();

    public int GetMaxHealth() => maxHealth;

    public int GetCurrentHealth() => currentHealth;

    public void SetCanPlayerMove(bool canPlayMove) { this.canPlayerMove = canPlayMove; }

    public void HealthDecay() { TakeDamage(healthDecayDamage); }

    public void TakeDamage(int damage)
    {
        SetHealth(currentHealth -= damage);
        healthBar.SetHealth(currentHealth);
    }

    public void Heal(int heal)
    {
        SetHealth(currentHealth += heal);
        healthBar.SetHealth(currentHealth);
    }

    public void SetHealth(int health)
    {
        if (health < 0) { currentHealth = 0; }
        
        else if (health > maxHealth) { currentHealth = maxHealth; }
        
        else { currentHealth = health; }
    }

    public Transform GetClosestEnemy()
    {
        Transform closestEnem = null;
        float distToClosestEnem = Mathf.Infinity;

        foreach (Transform enem in enemyHash)
        {
            float distToEnem = (enem.position - transform.position).sqrMagnitude;

            if (distToEnem < distToClosestEnem)
            {
                distToClosestEnem = distToEnem;
                closestEnem = enem;
            }
        }
        return closestEnem;
    }

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        targetPosition = rb2D.position;
        currentHealth = maxHealth;
        playerColl = this.GetComponent<Collider2D>();
        nextFire = Time.time;
        InvokeRepeating("HealthDecay", healthDecayTime, healthDecayTime);
        canPlayerMove = true;
    }

    private void Update()
    {
        if (PauseManager.Instance.GamePaused) { return; }

        if (canPlayerMove && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began
                && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                targetPosition = Camera.main.ScreenToWorldPoint(touch.position);
            }
        }
        else if (canPlayerMove && Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (!canPlayerMove)
        {
            targetPosition = rb2D.position;
        }

        if (rb2D.position == targetPosition && enemyHash.Count > 0) { PeriodicRangedAttack(); }

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

    private void PeriodicRangedAttack()
    {
        if (Time.time > nextFire)
        {
            proj = Instantiate(projectile, transform.position, Quaternion.identity)
                .GetComponent<ProjectileController>();

            if (proj != null && enemyHash.Count > 0)
            {
                proj.SetUpProjectile(GetClosestEnemy(), playerColl);
            }

            nextFire = Time.time + fireRate;
        }
    }
}
