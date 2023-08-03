using UnityEngine;
using UnityEngine.UI;

public class CardHandler : MonoBehaviour
{
    [SerializeField]
    private string cardName = "null";
    [SerializeField]
    private float cooldown = 15;
    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private CardManager manager;
    private Image cardImage;
    private Button cardButton;

    private void Awake()
    {
        cardImage = GetComponent<Image>();
        cardButton = GetComponent<Button>();
        CardIsPlayable();
    }

    private void CardIsPlayable()
    { // Placeholder until sprites are made
        cardImage.color = new Color32(130, 130, 130, 255);
        cardButton.interactable = true;
    }

    private void CardOnCooldown()
    { // Placeholder until sprites are made
        cardImage.color = new Color32(0, 0, 0, 255);
        cardButton.interactable = false;
        Invoke("CardIsPlayable", cooldown);
    }

    public void OnTap_PlayCard()
    {
        CardOnCooldown();
        player.SetCanPlayerMove(false);
        // Going to have to do stuff here to perform the tap drag then let go casting
        player.SetCanPlayerMove(true);
        manager.PlayCard(cardName);
    }
}
