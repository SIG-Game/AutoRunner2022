using UnityEngine;

public class DebugPlayerPrefsDeleter : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("PlayerPrefs deleted");
            PlayerPrefs.DeleteAll();
        }
    }
}
