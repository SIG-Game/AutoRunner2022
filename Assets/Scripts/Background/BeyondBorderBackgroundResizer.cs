// Thanks to Loek van den Ouweland for basic scaling code explanation;
// https://www.loekvandenouweland.com/content/stretch-unity-sprite-to-fill-the-screen.html.
// This code increases/decreases the size of the GameObject sprite so that it can cover the empty left/right background space that exists 
// when the player is using a large/horizontal screen to play the game. The sizing is dependent on the distance between the assigned border's 
// corresponding side (enum Side) and the same camera border side. NOTE: This script must be applied to 2 filler sprites (Right and Left) to 
// fill all empty space to the left and right of the game screen. This script was created for tiled continuous sprites in mind, which is why 
// the size of the sprite is altered, not the scale.
using UnityEngine;

public class BeyondBorderBackgroundResizer : MonoBehaviour
{
    private enum Side {Left, Right}; // Right if filling the space for the right side of the screen, Left otherwise

    private float borderEdge;
    private Vector2 currentCameraSize;
    private SpriteRenderer beyondBorderBgSprite; 
    [SerializeField] private SpriteRenderer borderSprite;
    [SerializeField] private Side side;


    private void Awake()
    {
        float cameraHeight = Camera.main.orthographicSize * 2;
        currentCameraSize = new Vector2(cameraHeight * Camera.main.aspect, cameraHeight);
        float borderWidth = borderSprite.size.x * borderSprite.transform.localScale.x;
        beyondBorderBgSprite = GetComponent<SpriteRenderer>();

        if (side == Side.Left) 
        {
            borderEdge = borderSprite.transform.position.x - (borderWidth / 2);
        } 
        else 
        {
            borderEdge = borderSprite.transform.position.x + (borderWidth / 2);
        }

        UpdateBackgroundFillSize();
    }


    // UpdateBackgroundFillSize
    // This function updates the empty right/left space.
    private void UpdateBackgroundFillSize()
    {
        float cameraEdge;

        if (side == Side.Left) 
        {
            cameraEdge = Camera.main.transform.position.x - (currentCameraSize.x / 2);
        } 
        else 
        {
            cameraEdge = Camera.main.transform.position.x + (currentCameraSize.x / 2);
        }

        // If width of borderSprite is partially/fully outside of the camera, no need to resize sprite.
        if ((side == Side.Right && borderEdge < cameraEdge) || (side == Side.Left && borderEdge > cameraEdge)) 
        {
            // The sizing factor is calculated, with the sprite renderer transformed to fill an empty side of the screen.
            float bgFillWidth = Mathf.Abs(borderEdge - cameraEdge);
            float bgFillHeight = currentCameraSize.y;
            transform.position = new Vector2((borderEdge + cameraEdge) / 2, Camera.main.transform.position.y);
            beyondBorderBgSprite.size = new Vector2(bgFillWidth / transform.localScale.x, bgFillHeight / transform.localScale.y);
        }
    }


    private void Update()
    {
        float cameraHeight = Camera.main.orthographicSize * 2;
        Vector2 newCameraSize = new Vector2(cameraHeight * Camera.main.aspect, cameraHeight);
        
        if (currentCameraSize != newCameraSize) 
        {            
            currentCameraSize = newCameraSize;
            UpdateBackgroundFillSize();
        }
    }
}