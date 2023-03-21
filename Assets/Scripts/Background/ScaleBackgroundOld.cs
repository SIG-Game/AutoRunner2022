using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Old script for scaling the background (no longer used)
//
public class ScaleBackground : MonoBehaviour
{
    //This is Main Camera in the Scene
    Camera m_MainCamera;
    [SerializeField]
    private SpriteRenderer sprRend;
    [SerializeField]
    private RectTransform canvas;
    float height;
    float pixWidth;

    // Start is called before the first frame update
    void Start()
    {
        //This gets the Main Camera from the Scene
        m_MainCamera = Camera.main;
        height = 4000;
        pixWidth = m_MainCamera.pixelWidth;
        //Debug.Log(pixWidth);
    }

    // Update is called once per frame
    void Update()
    {
        
        sprRend.size = new Vector2(canvas.rect.width, height);
        //sprRend.size = new Vector2(m_MainCamera.pixelWidth, 2000);

        /*
        if (Input.GetKey(KeyCode.Space))
        {
            sprRend.size += new Vector2(0.05f, 0.01f);
            Debug.Log("Sprite size: " + sprRend.size.ToString("F2"));
        }
        */
    }
}
