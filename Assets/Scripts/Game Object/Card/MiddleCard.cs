public class MiddleCard : Card
{
    public override bool TryPlayCard()
    {
        player.TakeDamage(20);
        return true;
    }
}