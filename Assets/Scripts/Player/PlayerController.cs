using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float movementSpeed;

    private Rigidbody2D rb2D;
    private Vector2 targetPosition;

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
        targetPosition = rb2D.position;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        // This may be unnecessary because it seems that touches are registered as clicks.
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            targetPosition = Camera.main.ScreenToWorldPoint(touch.position);
        }
    }

    private void FixedUpdate() {
        Vector2 newPosition = Vector2.MoveTowards(rb2D.position, targetPosition, movementSpeed);
        rb2D.MovePosition(newPosition);

        // TODO: Maybe set targetPosition to currentPosition when the player is stopped. Then, the player
        // won't continually try to reach an unreachable targetPosition when blocked by a collider.
    }
}
