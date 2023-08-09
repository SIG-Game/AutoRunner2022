using UnityEngine;

public class QuitHandler : MonoBehaviour
{
    public void QuitButton_OnClick()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
