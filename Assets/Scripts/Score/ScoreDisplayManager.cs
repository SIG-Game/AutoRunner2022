using UnityEngine;
using TMPro;

public class ScoreDisplayManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highScore;
    [SerializeField]
    private int level;

    private void Awake()
    {
        highScore.text = string.Format("High Score: {0:00000}",
                                       PlayerPrefs.GetFloat("lvl" + level + "HighScore"));
    }
}
