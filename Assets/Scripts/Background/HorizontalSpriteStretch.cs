//
// Thanks to Loek van den Ouweland for scaling code explanation;
// their article is where I came across a variation of this code.
// van den Ouweland, L. (2019, October 9). STRETCH A UNITY SPRITE TO FILL THE SCREEN IN A 2D GAME (GAMEOBJECT, NOT UI-CANVAS). 
// Loek van den Ouweland Software Engineering. Retrieved March 20, 2023, from https://www.loekvandenouweland.com/content/stretch-unity-sprite-to-fill-the-screen.html
//
// This code scales the background sprite so that it is horizontal fit to the main camera.
//
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalSpriteStretch : MonoBehaviour
{
    private float cameraHeight;
    private float cameraWidth;
    private float spriteWidth;
    private float spriteHeight;
    private float scaleFactorX;
    private float scaleFactorY;
    private float newScaleFactorX;
    private float newScaleFactorY;
    
    Vector2 currentSize;
    Vector2 newSize;
    Vector2 scale;

    void Awake()
    {
        var spriteSize = gameObject.GetComponent<SpriteRenderer>().bounds.size;

        //
        // First, size of the camera is obtained
        //
        cameraHeight = Camera.main.orthographicSize * 2;
        cameraWidth = cameraHeight * Camera.main.aspect;
        Debug.Log(cameraWidth + ", " + cameraHeight);
        currentSize = new Vector2(cameraWidth, cameraHeight);
    }
}
/*
        //
        // Next, size of the sprite is obtained
        //
        spriteWidth = spriteSize.x;
        spriteHeight = spriteSize.y;

        //
        // Finally, the scaling factor is calculated, with the sprite renderer transformed to fill the screen
        //
        scaleFactorX = cameraWidth / spriteWidth;
        scaleFactorY = cameraHeight / spriteHeight;
        scale = transform.localScale;
        transform.localScale = new Vector2(transform.localScale.x * scaleFactorX, transform.localScale.y * scaleFactorY);
    }

    // Update is called once per frame
    void Update()
    {
        cameraHeight = Camera.main.orthographicSize * 2;
        cameraWidth = cameraHeight * Camera.main.aspect;
        newSize = new Vector2(cameraWidth, cameraHeight);

        if (currentSize != newSize) {  // screen is a different size            
            newScaleFactorX = cameraWidth / spriteWidth;
            newScaleFactorY = cameraHeight / spriteHeight;
            
            scale = transform.localScale;
            transform.localScale = new Vector2(transform.localScale.x * (newScaleFactorX/scaleFactorX), transform.localScale.y * (newScaleFactorY/scaleFactorY));
            
            //
            // Current values updated with new values
            //
            currentSize = newSize;
            scaleFactorX = newScaleFactorX;
            scaleFactorY = newScaleFactorY;
        }
    }
}
*/
