using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("Quit\n");
        Application.Quit();
    }
}
