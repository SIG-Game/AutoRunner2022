using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void QuitButton_OnClick()
    {
        Debug.Log("Quit\n");
        Application.Quit();
    }
}
