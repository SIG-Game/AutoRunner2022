using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Special thanks to Root Games for scrolling background explanation from Unity 2D: Scrolling Background.
// [Video]. Youtube. Retrieved January 23, 2023 from https://www.youtube.com/watch?v=Wz3nbQPYwss

public class ScrollingBackgroundOld : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private Renderer bgRenderer;
     
    void Update()
    {
        // Time.timeScale added to stop background from moving when screen is paused
        // Time.timeScale is the speed of the game
        bgRenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime * Time.timeScale);
    }
}
