using UnityEngine;
using TMPro;

public class OverallScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highScore;

    private float overallScore;

    private void Awake()
    {
        for (int i = 0; i <= Constants.lastLevel; i++)
        { // Infinite level is currently saved as "lvl0HighScore"
            overallScore += PlayerPrefs.GetFloat("lvl" + i + "HighScore");
        }

        highScore.text = string.Format("Overall Score: {0:00000}", overallScore);
    }
}