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
    private float dispScoreTransSpeed = 1.0f;

    private int score,
                displayScore;
    private float startPlayerYPos;
    private string sceneHighScoreKey;

    public void EnemyFelled() { score += enemyFelledPts; }

    public void BossFelled(int pts) { score += pts; }

    public void UpdateScoreDisplay()
    {
        scoreText.text = string.Format("Score: {0:00000}", displayScore);
    }

    public void LevelEnd()
    {
        int pastHighScore = PlayerPrefs.GetInt(sceneHighScoreKey);

        if (playerTransform.position.y > startPlayerYPos)
        {
            score += playerDistPtsMultiplier * (int) (playerTransform.position.y - startPlayerYPos);
        }

        if (score > pastHighScore) { PlayerPrefs.SetInt(sceneHighScoreKey, score); }
    }

    private void Awake()
    {
        Instance = this;
        startPlayerYPos = playerTransform.position.y;
        int buildIndex = SceneManager.GetActiveScene().buildIndex;

        if (buildIndex == 0)
        {
            sceneHighScoreKey = "lvlInfHighScore";
        }
        else
        {
            sceneHighScoreKey = "lvl" + buildIndex + "HighScore";
        }
    }

    private void Update()
    {
        displayScore = (int) Mathf.MoveTowards(displayScore, score, dispScoreTransSpeed);
        UpdateScoreDisplay();
    }
}
