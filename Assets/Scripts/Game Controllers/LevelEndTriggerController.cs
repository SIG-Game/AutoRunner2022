using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTriggerController : MonoBehaviour
{
    public int nextSceneLoad,
               lastLevel;

    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        lastLevel = 2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if ((SceneManager.GetActiveScene().buildIndex - 1) == lastLevel)
            {
                Debug.Log("YOU WIN!");
                SceneManager.LoadScene("StartMenu");
            }
            else
            {
                // Move to next level
                SceneManager.LoadScene(nextSceneLoad);

                // Setting Int for Index
                if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                }
            }
        }
    }
}
