using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public float Score
    {
        get => score;
        private set { score = value; }
    }

    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private float playerDistPtsMultiplier = 10.0f;
    [SerializeField]
    private float enemyFelledPts = 100.0f;
    [SerializeField]
    private float dispScoreTransSpeed = 100.0f;

    private float score,
                  displayScore,
                  pastHighScore,
                  startPlayerYPos;

    private string sceneHighScore;
    
    // Pass a positive for increase, negative for decrease
    public void ChangeScore(float amount) { Score += amount; }

    public void EnemyFelled() { ChangeScore(enemyFelledPts); }

    public void BossFelled(float pts) { ChangeScore(pts); }

    public void UpdateScoreDisplay()
    {
        scoreText.text = string.Format("Score: {0:00000}", displayScore);
    }

    public void LevelEnd()
    {
        if (playerTransform.position.y > startPlayerYPos)
        {
            ChangeScore(playerDistPtsMultiplier * (playerTransform.position.y - startPlayerYPos));
        }

        Score = (pastHighScore > Score) ? pastHighScore : Score;
        PlayerPrefs.SetFloat(sceneHighScore, Score);
    }

    private void Awake()
    {
        Instance = this;
        startPlayerYPos = playerTransform.position.y;
        int buildIndex = SceneManager.GetActiveScene().buildIndex;

        if (buildIndex == 0)
        {
            sceneHighScore = "lvlIHighScore";
        }
        else
        {
            sceneHighScore = "lvl" + buildIndex + "HighScore";
        }
        pastHighScore = PlayerPrefs.GetFloat(sceneHighScore);
    }

    private void Update()
    {
        displayScore = Mathf.MoveTowards(displayScore, score, dispScoreTransSpeed * Time.deltaTime);
        UpdateScoreDisplay();
    }
}
