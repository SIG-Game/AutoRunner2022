using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;

    public void PauseButton_OnClick()
    {
        PauseManager.Instance.GamePaused = !PauseManager.Instance.GamePaused;
        pauseMenuUI.SetActive(PauseManager.Instance.GamePaused);
    }
}
