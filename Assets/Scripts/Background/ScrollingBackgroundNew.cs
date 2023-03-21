using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//
// Thanks to Tarodev for the video explaining one method scrolling backgrounds
// [Video]. Youtube. Retrieved March 20, 2023 from https://www.youtube.com/watch?v=-6H-uYh80vc
//
// New script for scrolling the background (not currently used; using 2 identical sprites
// to simulate looping will be our future approach for background scrolling)
//
public class ScrollingBackgroundNew : MonoBehaviour
{
    //
    // I attempted to switch the RawImage variable _img in the video with a sprite variable, but was unsuccessful.
    // Refer to the video for the correct implementation.
    //
    [SerializeField] private Sprite _spr;
    [SerializeField] private float _x, _y;

    // Update is called once per frame
    void Update()
    {
        //_spr.uv = new uv(__spr.uv.position + new Vector2(_x, _y) * Time.deltaTime * Time.timeScale, _spr.uv.size);
    }
}
