public class LeftCard : Card
{
    public override bool TryPlayCard()
    {
        player.Heal(20);
        return true;
    }
}
