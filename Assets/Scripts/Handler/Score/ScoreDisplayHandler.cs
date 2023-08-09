using UnityEngine;
using TMPro;

public class ScoreDisplayHandler : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highScore;
    [SerializeField]
    private string level;

    private void Awake()
    {
        highScore.text = string.Format("High Score: {0:00000}",
                                       PlayerPrefs.GetInt("lvl" + level + "HighScore"));
    }
}
