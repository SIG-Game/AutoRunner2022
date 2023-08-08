using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField]
    private string cardName = "null";
    [SerializeField]
    private float cooldown = 15;
    [SerializeField]
    private CardManager manager;
    private Image cardImage;
    private Button cardButton;
    private Vector2 cardOriginPos;
    private RectTransform rectTransform;

    private void Awake()
    {
        cardImage = GetComponent<Image>();
        cardButton = GetComponent<Button>();
        rectTransform = GetComponent<RectTransform>();
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

    public void OnBeginDrag(PointerEventData eventData)
    {
        cardOriginPos = rectTransform.anchoredPosition;
        manager.PlayerCantMove();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        manager.PlayerCanMove();
        rectTransform.anchoredPosition = cardOriginPos;

        if (manager.PlayCard(cardName))
        {
            CardOnCooldown();
        }
    }
}
