using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour {
    [SerializeField] private string nameOfSceneToLoad;

    public void LoadSceneButton_OnClick() {
        SceneManager.LoadScene(nameOfSceneToLoad);
    }
}
