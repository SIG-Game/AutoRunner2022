using UnityEngine;

public class HPPickupInteract : MonoBehaviour
{
    [SerializeField]
    private int hpPickupVal = 100;

    private void OnTriggerStay2D(Collider2D coll2D)
    {
        PlayerController player = coll2D.GetComponent<PlayerController>();

        if (player != null && player.GetCurrentHealth() != player.GetMaxHealth())
        {
            player.Heal(hpPickupVal);
            Destroy(gameObject);
        }
    }
}
