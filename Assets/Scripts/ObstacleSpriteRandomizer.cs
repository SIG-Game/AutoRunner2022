using UnityEngine;

public class ObstacleSpriteRandomizer : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;

    private void Start()
    {
        SpriteRenderer obstacleSprite = GetComponent<SpriteRenderer>();
        obstacleSprite.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
