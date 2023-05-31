using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRandomSprite : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer obstacleSprite = gameObject.GetComponent<SpriteRenderer>();
        obstacleSprite.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
