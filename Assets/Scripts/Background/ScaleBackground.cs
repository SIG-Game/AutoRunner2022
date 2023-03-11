using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBackground : MonoBehaviour
{
    //This is Main Camera in the Scene
    Camera m_MainCamera;
    //Canvas canvas;
    //private Rigidbody2D rb;
    [SerializeField]
    private SpriteRenderer sprRend;
    [SerializeField]
    private Rect canvas;

/*
    void Awake()
    {
        //rb = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        //rb.bodyType = RigidbodyType2D.Kinematic;
    }
*/

    // Start is called before the first frame update
    void Start()
    {
        //This gets the Main Camera from the Scene
        m_MainCamera = Camera.main;

        //gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("image256x128");
        //gameObject.transform.Translate(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //
        // TODO: Try using canvas's size or scale or height/width
        //
        // The canvas is a rectangle, so use rectangle functions to get width/height
        //
        //sprRend.size = new Vector2(canvas.width, canvas.width * 4);

        sprRend.size = new Vector2(m_MainCamera.pixelWidth, sprRend.size.y);


        //Press the Space key to increase the size of the sprite
        /*
        if (Input.GetKey(KeyCode.Space))
        {
            sprRend.size += new Vector2(0.05f, 0.01f);
            Debug.Log("Sprite size: " + sprRend.size.ToString("F2"));
        }
        */
    }
}
