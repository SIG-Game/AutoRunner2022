using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;

    public bool PlayCard(string card)
    {
        switch (card)
        {
            case "LeftCard":
                return(LeftCard());
            case "MidCard":
                return(MidCard());
            case "RightCard":
                return(RightCard());
            default:
                Debug.Log("Card name is null or not handled.");
                return false;
        }
    }

    public void PlayerCanMove() { player.SetCanPlayerMove(true); }

    public void PlayerCantMove() { player.SetCanPlayerMove(false); }

    // All functions are for testing purposes, none of these are final
    private bool LeftCard() { player.Heal(20); return true; }

    private bool MidCard() { player.TakeDamage(20); return true; }

    private bool RightCard()
    { // Instantly kills closest enemy and leaves the player at 1 hp
        Transform enem = player.GetClosestEnemy();

        if (enem != null)
        {
            enem.GetComponent<EnemyController>().Die();
            player.TakeDamage(player.GetCurrentHealth() - 1);
            return true;
        }
        return false;
    }
}
