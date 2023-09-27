using UnityEngine;
using TMPro;

public class OverallScoreController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highScore;

    private void Awake()
    {
        int overallScore = 0;

        for (int i = 1; i <= Constants.lastLevel; i++)
        {
            overallScore += PlayerPrefs.GetInt("lvl" + i + "HighScore");
        }
        overallScore += PlayerPrefs.GetInt("lvlInfHighScore");

        highScore.text = string.Format("Overall Score: {0:00000}", overallScore);
    }
}