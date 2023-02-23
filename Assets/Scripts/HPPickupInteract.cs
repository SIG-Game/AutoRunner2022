using UnityEngine;

public class HPPickupInteract : MonoBehaviour
{
    // Private Variables \\
    [SerializeField]
    private int hpPickupVal { get; set; } = 100;

    // Methods \\
    public void OnTriggerEnter2D(Collider2D coll2D)
    {
        PlayerController player = coll2D.GetComponent<PlayerController>();

        if (player.getCurrentHealth() != player.getMaxHealth())
        {
            player.Heal(hpPickupVal);
            Destroy(gameObject);
        }
    }
}
