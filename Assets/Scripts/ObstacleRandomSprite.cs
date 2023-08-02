using UnityEngine;

public class ObstacleRandomSprite : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;

    private void Start()
    {
        SpriteRenderer obstacleSprite = GetComponent<SpriteRenderer>();
        obstacleSprite.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
