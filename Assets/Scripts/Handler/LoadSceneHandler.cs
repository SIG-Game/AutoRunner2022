using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneHandler : MonoBehaviour
{
    [SerializeField]
    private string nameOfSceneToLoad;

    public void LoadScene()
    {
        try
        {
            SceneManager.LoadScene(nameOfSceneToLoad);
        }
        catch
        {
            Debug.Log($"Scene {nameOfSceneToLoad} not found.");
        }
    }
}