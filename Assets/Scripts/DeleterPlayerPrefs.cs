using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleterPlayerPrefs : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
