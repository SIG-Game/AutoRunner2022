using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;

    public void Pause()
    {
        PauseController.Instance.GamePaused = !PauseController.Instance.GamePaused;
        pauseMenuUI.SetActive(PauseController.Instance.GamePaused);
    }
}
