using UnityEngine;
using TMPro;

public class OverallScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highScore;

    private void Awake()
    {
        float overallScore = 0;

        for (int i = 1; i <= Constants.lastLevel; i++)
        {
            overallScore += PlayerPrefs.GetFloat("lvl" + i + "HighScore");
        }
        overallScore += PlayerPrefs.GetFloat("lvlIHighScore");

        highScore.text = string.Format("Overall Score: {0:00000}", overallScore);
    }
}