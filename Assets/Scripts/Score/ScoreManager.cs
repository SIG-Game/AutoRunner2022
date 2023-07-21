using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private int playerDistPtsMultiplier = 10;
    [SerializeField]
    private int enemyFelledPts = 100;
    [SerializeField]
    private int dispScoreTransSpeed = 100;

    private int score,
                displayScore,
                startPlayerYPos;

    private string sceneHighScoreKey;
    
    // Pass a positive for increase, negative for decrease
    public void ChangeScore(int amount) { score += amount; }

    public void EnemyFelled() { ChangeScore(enemyFelledPts); }

    public void BossFelled(int pts) { ChangeScore(pts); }

    public void UpdateScoreDisplay()
    {
        scoreText.text = string.Format("Score: {0:00000}", displayScore);
    }

    public void LevelEnd()
    {
        int pastHighScore = PlayerPrefs.GetInt(sceneHighScoreKey);

        if (playerTransform.position.y > startPlayerYPos)
        {
            ChangeScore(playerDistPtsMultiplier * (int) (playerTransform.position.y - startPlayerYPos));
        }

        if (score > pastHighScore) { PlayerPrefs.SetInt(sceneHighScoreKey, score); }
    }

    private void Awake()
    {
        Instance = this;
        startPlayerYPos = (int) playerTransform.position.y;
        int buildIndex = SceneManager.GetActiveScene().buildIndex;

        if (buildIndex == 0)
        {
            sceneHighScoreKey = "lvlIHighScore";
        }
        else
        {
            sceneHighScoreKey = "lvl" + buildIndex + "HighScore";
        }
    }

    private void Update()
    {
        displayScore = (int) Mathf.MoveTowards(displayScore, score, dispScoreTransSpeed * Time.deltaTime);
        UpdateScoreDisplay();
    }
}
