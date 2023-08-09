using UnityEngine;

public class PauseManager : MonoBehaviour {
    public static PauseManager Instance;

    public bool GamePaused {
        get => gamePaused;
        set {
            gamePaused = value;
            Time.timeScale = gamePaused ? 0f : 1f;
        }
    }

    private bool gamePaused;

    private void Awake() {
        Instance = this;

        GamePaused = false;
    }

    private void OnDestroy() {
        Instance = null;
    }
}
