public class SelfHealCard : CardController
{
    protected override bool TryPlayCard()
    {
        player.Heal(20);
        return true;
    }
}
