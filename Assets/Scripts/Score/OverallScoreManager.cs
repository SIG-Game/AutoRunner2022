using UnityEngine;
using TMPro;

public class OverallScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highScore;

    private float overallScore;
    private int lastLevel = 2;

    private void Awake()
    {
        for (int i = 0; i <= lastLevel; i++)
        {
            overallScore += PlayerPrefs.GetFloat("lvl" + i + "HighScore");
        }

        highScore.text = string.Format("Overall Score: {0:00000}", overallScore);
    }
}