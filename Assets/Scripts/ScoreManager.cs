using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public float Score
    {
        get { return score; }
        private set { score = value; }
    }

    private const float moveMulti4Pts = 10.0f, // The value to multiply the distance traveled by
                        enemyFelledPts = 100.0f; // The points killing an enemy is worth

    private float score,
                  pastScore,
                  startY;

    public void SetStartY(float y) { startY = y; }
    
    public void IncreaseScore(float amount) { Score += amount; }

    public void EnemyFelled()
    {
        IncreaseScore(enemyFelledPts);
    }

    public void BossFelled(float pts)
    {
        IncreaseScore(pts);
    }

    public void AbruptLevelEnd()
    {
        GameObject player = GameObject.FindWithTag("Player");
        LevelEnd(player.transform.position.y);
    }

    public void LevelEnd(float curY)
    {
        if (curY > startY)
        {
            IncreaseScore(moveMulti4Pts * (curY - startY));
        }

        Score = (pastScore > Score) ? pastScore : Score;
        PlayerPrefs.SetFloat("lvl" + SceneManager.GetActiveScene().buildIndex + "HighScore", Score);
    }

    private void Awake()
    {
        Instance = this;
        pastScore = PlayerPrefs.GetFloat("lvl" + SceneManager.GetActiveScene().buildIndex + "HighScore");
    }
}
