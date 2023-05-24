using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTriggerController : MonoBehaviour
{
    [SerializeField]
    private int indexForNextScene;

    [SerializeField]
    private const int lastLevel = 2;

    private void Start()
    {
        indexForNextScene = SceneManager.GetActiveScene().buildIndex + 1;
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
                SceneManager.LoadScene(indexForNextScene);

                if (indexForNextScene > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", indexForNextScene);
                }
            }
        }
    }
}
