public class SelfDamageCard : CardController
{
    protected override bool TryPlayCard()
    {
        player.TakeDamage(20);
        return true;
    }
}