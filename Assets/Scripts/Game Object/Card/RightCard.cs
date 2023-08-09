using UnityEngine;

public class RightCard : Card
{
    public override bool TryPlayCard()
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
