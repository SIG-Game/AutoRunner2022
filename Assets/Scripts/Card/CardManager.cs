using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;

    public void PlayCard(string card)
    {
        switch (card)
        {
            case "null":
                Debug.Log("Card name is null.");
                break;
            case "LeftCard":
                LeftCard();
                break;
            case "MidCard":
                MidCard();
                break;
            case "RightCard":
                RightCard();
                break;
        }
    }

    // All functions are for testing purposes, none of these are final
    private void LeftCard() { player.Heal(20); }

    private void MidCard() { player.TakeDamage(20); }

    private void RightCard()
    { // Instantly kills closest enemy and leaves the player at 1 hp
        Transform enem = player.GetClosestEnemy();
        enem.GetComponent<EnemyController>().Die();
        player.TakeDamage(player.GetCurrentHealth() - 1);
    }
}
