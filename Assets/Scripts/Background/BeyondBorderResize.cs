// Thanks to Loek van den Ouweland for scaling code explanation;
// their article is where I came across a script with similar code for obtaining camera values and scaling a background.
// van den Ouweland, L. (2019, October 9). STRETCH A UNITY SPRITE TO FILL THE SCREEN IN A 2D GAME (GAMEOBJECT, NOT UI-CANVAS). 
// Loek van den Ouweland Software Engineering. Retrieved March 20, 2023, from 
// https://www.loekvandenouweland.com/content/stretch-unity-sprite-to-fill-the-screen.html.
// This code increases/decreases the size of the GameObject sprite so that it can cover the empty left/right background space that exists 
// when the player is using a large/horizontal screen to play the game. The sizing is dependent on the distance between the assigned border's 
// corresponding side (boolean right) and the same camera border side. NOTE: This script must be applied to 2 filler sprites (right and left) to 
// fill all empty space to the left and right of the game screen. This script was created for tiled continuous sprites in mind, which is why 
// the size of the sprite is altered, not the scale.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeyondBorderResize : MonoBehaviour
{
    private float cameraHeight;
    private float cameraWidth;
    private float spriteWidth;
    private float spriteHeight;
    private float sizeFactorWidth;
    private float sizeFactorHeight;
    private float borderWidth;
    private float borderEdge;
    private float cameraEdge;
    private float localXScale;
    private Vector2 currentSize;
    private SpriteRenderer fillerSprite;

    public bool right;  // true if filling the space for the right side of the screen, false if otherwise
    public SpriteRenderer border;  // variable to store border sprite
    
    
    void Awake()
    {
        cameraHeight = Camera.main.orthographicSize * 2;
        cameraWidth = cameraHeight * Camera.main.aspect;
        currentSize = new Vector2(cameraWidth, cameraHeight);
        localXScale = transform.localScale.x;
        borderWidth = border.size.x * border.transform.localScale.x;

        if (!right) {
            borderEdge = border.transform.position.x - (borderWidth / 2);
            cameraEdge = Camera.main.transform.position.x - (cameraWidth / 2);
        } else {
            borderEdge = border.transform.position.x + (borderWidth / 2);
            cameraEdge = Camera.main.transform.position.x + (cameraWidth / 2);
        }
        
        fillerSprite = GetComponent<SpriteRenderer>();

        // If background + edges combined are already wider than the camera, no need to resize sprite.
        if ((right && borderEdge < cameraEdge) || (!right && borderEdge > cameraEdge)) {
            spriteWidth = fillerSprite.size.x;
            spriteHeight = fillerSprite.size.y;

            // The sizing factor is calculated, with the sprite renderer transformed to fill an empty side of the screen.
            if (!right) {
                sizeFactorWidth = Mathf.Abs(borderEdge - cameraEdge) / spriteWidth;
            } else {
                sizeFactorWidth = Mathf.Abs(cameraEdge - borderEdge) / spriteWidth;
            }

            sizeFactorHeight = cameraHeight / spriteHeight;
            transform.position = new Vector2((borderEdge + (cameraEdge)) / 2, Camera.main.transform.position.y);
            fillerSprite.size = new Vector2(spriteWidth * sizeFactorWidth / localXScale, spriteHeight * sizeFactorHeight / localXScale);
        }
    }


    // ChangeSize
    // This function updates the empty right/left space when the camera size has changed (just like the Awake function).
    private void ChangeSize()
    {
        float newSizeFactorWidth;
        float newSizeFactorHeight;

        if (!right) {
            cameraEdge = Camera.main.transform.position.x - (cameraWidth / 2);
        } else {
            cameraEdge = Camera.main.transform.position.x + (cameraWidth / 2);
        }
        
        if ((right && borderEdge < cameraEdge) || (!right && borderEdge > cameraEdge)) { 
            spriteWidth = fillerSprite.size.x;
            spriteHeight = fillerSprite.size.y;
            
            if (!right) {
                newSizeFactorWidth = Mathf.Abs(borderEdge - cameraEdge) / spriteWidth;
            } else {
                newSizeFactorWidth = Mathf.Abs(cameraEdge - borderEdge) / spriteWidth;
            }

            newSizeFactorHeight = cameraHeight / spriteHeight;
            transform.position = new Vector2((borderEdge + (cameraEdge)) / 2, Camera.main.transform.position.y);
            fillerSprite.size = new Vector2(spriteWidth * newSizeFactorWidth / localXScale, spriteHeight * newSizeFactorHeight / localXScale);

            sizeFactorWidth = newSizeFactorWidth;
            sizeFactorHeight = newSizeFactorHeight;
        }
    }
    

    void Update()
    {
        Vector2 newSize;

        cameraHeight = Camera.main.orthographicSize * 2;
        cameraWidth = cameraHeight * Camera.main.aspect;
        newSize = new Vector2(cameraWidth, cameraHeight);

        if (currentSize != newSize) {            
            ChangeSize();
        }

        currentSize = newSize;
    }
}
