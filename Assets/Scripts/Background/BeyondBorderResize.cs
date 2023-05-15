//
// Thanks to Loek van den Ouweland for scaling code explanation;
// their article is where I came across a script with similar code for obtaining camera values and scaling a background.
// van den Ouweland, L. (2019, October 9). STRETCH A UNITY SPRITE TO FILL THE SCREEN IN A 2D GAME (GAMEOBJECT, NOT UI-CANVAS). 
// Loek van den Ouweland Software Engineering. Retrieved March 20, 2023, from https://www.loekvandenouweland.com/content/stretch-unity-sprite-to-fill-the-screen.html
//
// This code increases the size of the GameObject sprite so that it can cover the empty left/right background space that exists when the player is using a 
// large/horizontal screen to play the game. The sizing is dependent on the distance between the chosen border's corresponding side (boolean right) and the 
// same camera border side. NOTE: This script must be applied to 2 borders (right and left) to fill all empty space to the left and right of the game screen.
// This script was created for tiled continuous sprites in mind, which is why the size of the sprite is altered, not the scale.
//
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
    private float newSizeFactorWidth;
    private float newSizeFactorHeight;
    private float backgroundLeftWidth;
    private float backgroundRightWidth;
    private float backgroundLeftEdge;
    private float backgroundRightEdge;
    private float cameraLeftEdge;
    private float cameraRightEdge;
    private float sizeValue;

    public bool right;  // true if filling the space for the right side of the screen, false if otherwise
    
    Vector2 currentSize;
    Vector2 newSize;
    
    public SpriteRenderer leftBorder;  // variable to store left border sprite
    public SpriteRenderer rightBorder;  // variable to store right border sprite

    /*
     * ChangeSize
     *
     * This function updates the empty right/left space when the camera size has changed (similar to the Awake function).
    */
    private void ChangeSize () {
        cameraLeftEdge = Camera.main.transform.position.x - (cameraWidth / 2);  // stores x-value of the camera's left side
        cameraRightEdge = Camera.main.transform.position.x + (cameraWidth / 2);  // stores x-value of the camera's right side

        //
        // If background + edges combined are already wider than the camera, no need to resize sprite (just like Awake function).
        //
        if ((right && backgroundRightEdge < cameraRightEdge) || (!right && backgroundLeftEdge > cameraLeftEdge)) { 
            //
            // Next, size of the sprite is obtained.
            //
            spriteWidth = GetComponent<SpriteRenderer>().size.x;
            spriteHeight = GetComponent<SpriteRenderer>().size.y;
            
            //
            // Finally, the sizing factor is calculated, with the sprite renderer transformed to fill an empty side of the screen.
            //
            if (!right) {
                newSizeFactorWidth = Mathf.Abs(backgroundLeftEdge - cameraLeftEdge) / spriteWidth;
            } else {
                newSizeFactorWidth = Mathf.Abs(cameraRightEdge - backgroundRightEdge) / spriteWidth;
            }
            newSizeFactorHeight = cameraHeight / spriteHeight;
            
            if (!right) {
                transform.position = new Vector2((backgroundLeftEdge + (cameraLeftEdge)) / 2, Camera.main.transform.position.y);
            } else {
                transform.position = new Vector2((backgroundRightEdge + (cameraRightEdge)) / 2, Camera.main.transform.position.y);
            }
            GetComponent<SpriteRenderer>().size = new Vector2(spriteWidth * newSizeFactorWidth / sizeValue, spriteHeight * newSizeFactorHeight / sizeValue);

            sizeFactorWidth = newSizeFactorWidth;  // size values updated
            sizeFactorHeight = newSizeFactorHeight;
        }

        currentSize = newSize;  // camera size updated
    }
    

    void Awake()
    {
        //
        // First, size of the camera is obtained.
        //
        cameraHeight = Camera.main.orthographicSize * 2;
        cameraWidth = cameraHeight * Camera.main.aspect;
        //Debug.Log("Camera width and height: " + cameraWidth + ", " + cameraHeight);
        currentSize = new Vector2(cameraWidth, cameraHeight);
        sizeValue = transform.localScale.x;

        //
        // Then, the required border and its measurements are obtained.
        //
        if (!right) {
            leftBorder = GameObject.FindWithTag("LeftBorder").GetComponent<SpriteRenderer>();
            backgroundLeftWidth = leftBorder.size.x * leftBorder.transform.localScale.x;
            //Debug.Log("background left width: " + backgroundLeftWidth);
            backgroundLeftEdge = leftBorder.transform.position.x - (backgroundLeftWidth / 2);
            //Debug.Log("background left edge: " + backgroundLeftEdge);
        } else {
            rightBorder = GameObject.FindWithTag("RightBorder").GetComponent<SpriteRenderer>();
            backgroundRightWidth = rightBorder.size.x * rightBorder.transform.localScale.x;
            //Debug.Log("background right width: " + backgroundRightWidth);
            backgroundRightEdge = rightBorder.transform.position.x + (backgroundRightWidth / 2);
            //Debug.Log("background right edge: " + backgroundRightEdge);
        }

        //
        // X-value of edges are obtained from the camera as well.
        //
        cameraLeftEdge = Camera.main.transform.position.x - (cameraWidth / 2);
        cameraRightEdge = Camera.main.transform.position.x + (cameraWidth / 2);
        ///Debug.Log("Camera left and right edges: " + cameraLeftEdge + ", " + cameraRightEdge);

        //
        // If background + edges combined are already wider than the camera, no need to resize sprite.
        //
        if ((right && backgroundRightEdge < cameraRightEdge) || (!right && backgroundLeftEdge > cameraLeftEdge)) {
            //
            // Next, size of the sprite is obtained
            //
            spriteWidth = GetComponent<SpriteRenderer>().size.x;
            spriteHeight = GetComponent<SpriteRenderer>().size.y;
            //Debug.Log("Sprite width and height: " + spriteWidth + ", " + spriteHeight);

            //
            // Finally, the sizing factor is calculated, with the sprite renderer transformed to fill an empty side of the screen.
            //
            if (!right) {
                sizeFactorWidth = Mathf.Abs(backgroundLeftEdge - cameraLeftEdge) / spriteWidth;
            } else {
                sizeFactorWidth = Mathf.Abs(cameraRightEdge - backgroundRightEdge) / spriteWidth;
            }
            sizeFactorHeight = cameraHeight / spriteHeight;
            
            if (!right) {
                transform.position = new Vector2((backgroundLeftEdge + (cameraLeftEdge)) / 2, Camera.main.transform.position.y);
            } else {
                transform.position = new Vector2((backgroundRightEdge + (cameraRightEdge)) / 2, Camera.main.transform.position.y);
            }
            GetComponent<SpriteRenderer>().size = new Vector2(spriteWidth * sizeFactorWidth / sizeValue, spriteHeight * sizeFactorHeight / sizeValue);
        }
    }


    // Update is called once per frame
    void Update()
    {
        cameraHeight = Camera.main.orthographicSize * 2;
        cameraWidth = cameraHeight * Camera.main.aspect;
        newSize = new Vector2(cameraWidth, cameraHeight);

        if (currentSize != newSize) {  // screen is a different size            
            ChangeSize();
        }
    }
}
