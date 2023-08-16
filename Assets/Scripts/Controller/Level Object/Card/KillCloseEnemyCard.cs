using UnityEngine;

public class KillCloseEnemyCard : CardController
{
    protected override bool TryPlayCard()
    {
        Transform enem = player.GetClosestEnemy();

        if (enem != null)
        {
            enem.GetComponent<EnemyController>().Die();
            player.SetHealth(10);
            return true;
        }
        return false;
    }
}
