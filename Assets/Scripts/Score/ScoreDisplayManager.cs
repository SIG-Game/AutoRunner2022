using UnityEngine;
using TMPro;

public class ScoreDisplayManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highScore,
                            buttonTxt;
    private char level;

    private void Awake()
    {
        level = buttonTxt.text[buttonTxt.text.Length - 1];

        if (level == 'E')
        { // Infinite Mode ends in a capital E not a number like the other levels
            level = '0';
        }
        highScore.text = string.Format("High Score: {0:00000}",
                                       PlayerPrefs.GetFloat("lvl" + level + "HighScore"));
    }
}
