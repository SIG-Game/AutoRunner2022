//
// Massive thanks to Loek van den Ouweland for the scaling code and explanation;
// their article is where most of this code came from.
// van den Ouweland, L. (2019, October 9). STRETCH A UNITY SPRITE TO FILL THE SCREEN IN A 2D GAME (GAMEOBJECT, NOT UI-CANVAS). 
// Loek van den Ouweland Software Engineering. Retrieved March 20, 2023, from https://www.loekvandenouweland.com/content/stretch-unity-sprite-to-fill-the-screen.html 
//
// This code scales the background sprite so that it is horizontal fit to the main camera.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteStretch : MonoBehaviour
{
    float scaleFactorX;
    Vector3 newSize;
    Vector3 topRightCorner;
    float spriteWidth;
    float cameraX;
    [SerializeField]
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        //
        // First, position of the screen is obtained
        //
        topRightCorner = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        cameraX = Camera.main.transform.position.x;
        
        //
        // Then, width of the world space is obtained
        //
        var worldSpaceWidth = Mathf.Abs((topRightCorner.x - cameraX) * 2);
        
        //
        // Afterwards, size of the size is acquired
        //
        var spriteSize = gameObject.GetComponent<SpriteRenderer>().bounds.size;
        
        //
        // Finally, the scaling factor is calculated, with the sprite renderer transformed to fill the screen
        //
        spriteWidth = spriteSize.x;
        scaleFactorX = worldSpaceWidth / spriteSize.x;
        gameObject.transform.localScale = new Vector3(scaleFactorX, height, 1);
    }

    // Update is called once per frame
    void Update()
    {
        newSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        if (topRightCorner != newSize) {  // screen is a different size
            topRightCorner = newSize;
            var worldSpaceWidth = Mathf.Abs((topRightCorner.x - cameraX) * 2);
            scaleFactorX = worldSpaceWidth / spriteWidth;
            gameObject.transform.localScale = new Vector3(scaleFactorX, height, 1);
        }
    }
}
