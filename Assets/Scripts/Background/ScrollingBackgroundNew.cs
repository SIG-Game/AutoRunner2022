using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScrollingBackgroundNew : MonoBehaviour
{
    [SerializeField] private Sprite _spr;
    [SerializeField] private float _x, _y;

    // Update is called once per frame
    void Update()
    {
        //_spr.uv = new uv(__spr.uv.position + new Vector2(_x, _y) * Time.deltaTime * Time.timeScale, _spr.uv.size);
    }
}
