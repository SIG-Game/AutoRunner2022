using UnityEngine;

public class PauseButton : MonoBehaviour {
    [SerializeField] private GameObject pauseMenuUI;

    public void PauseButton_OnClick() {
        PauseController.Instance.GamePaused = !PauseController.Instance.GamePaused;
        pauseMenuUI.SetActive(PauseController.Instance.GamePaused);
    }
}
