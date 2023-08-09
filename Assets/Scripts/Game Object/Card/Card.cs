using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class Card : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField]
    protected float cooldown = 15;
    [SerializeField]
    protected PlayerController player;
    protected Image cardImage;
    protected Button cardButton;
    protected Vector2 cardOriginPos;
    protected RectTransform rectTransform;

    public abstract bool TryPlayCard();

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (cardButton.interactable)
        {
            cardOriginPos = rectTransform.anchoredPosition;
            player.SetCanPlayerMove(false);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (cardButton.interactable)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (cardButton.interactable)
        {
            player.SetCanPlayerMove(true);
            rectTransform.anchoredPosition = cardOriginPos;

            if (TryPlayCard()) { PutCardOnCooldown(); }
        }
    }

    private void Awake()
    {
        cardImage = GetComponent<Image>();
        cardButton = GetComponent<Button>();
        rectTransform = GetComponent<RectTransform>();
        MakeCardPlayable();
    }

    private void MakeCardPlayable()
    { // Additional functionality needed once we have sprites
        cardButton.interactable = true;
    }

    private void PutCardOnCooldown()
    { // Additional functionality needed once we have sprites
        cardButton.interactable = false;
        Invoke("MakeCardPlayable", cooldown);
    }
}
