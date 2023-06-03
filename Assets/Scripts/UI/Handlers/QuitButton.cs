using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void QuitButton_OnClick()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
