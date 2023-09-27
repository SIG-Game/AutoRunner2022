using UnityEngine;

public class TogglePauseMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;

    public void TogglePauseMenu()
    {
        PauseController.Instance.GamePaused = !PauseController.Instance.GamePaused;
        pauseMenuUI.SetActive(PauseController.Instance.GamePaused);
    }
}
