using UnityEngine;
using TMPro;

public class LevelHighScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highScore,
                            buttonTxt;

    private void Awake()
    {
        highScore.text = string.Format("Score: {0:00000}",
                                       PlayerPrefs.GetFloat("lvl" +
                                                            buttonTxt.text[buttonTxt.text.Length - 1] +
                                                            "HighScore"));
    }
}
