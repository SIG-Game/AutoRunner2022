using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTriggerController : MonoBehaviour
{
    [SerializeField]
    private int indexForNextScene;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        { // This logic is temporary for the current non-infinite infinite level
            indexForNextScene = Constants.lastLevel + 1;
        }
        else
        {
            indexForNextScene = SceneManager.GetActiveScene().buildIndex + 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreManager.Instance.LevelEnd();

            if ((SceneManager.GetActiveScene().buildIndex) == Constants.lastLevel)
            {
                Debug.Log("YOU WIN!");
                SceneManager.LoadScene("StartMenu");
            }
            else
            {
                SceneManager.LoadScene(indexForNextScene);

                if (indexForNextScene > PlayerPrefs.GetInt("highestLvlUnlock"))
                {
                    PlayerPrefs.SetInt("highestLvlUnlock", indexForNextScene);
                }
            }
        }
    }
}
