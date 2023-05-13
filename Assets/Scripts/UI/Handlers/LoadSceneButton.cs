using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour {
    [SerializeField] private string nameOfSceneToLoad;

    public void LoadSceneButton_OnClick() {
        try
        {
            SceneManager.LoadScene(nameOfSceneToLoad);
        }
        catch
        {
            Debug.Log("Scene has not been implemented yet.");
        }
    }
}
