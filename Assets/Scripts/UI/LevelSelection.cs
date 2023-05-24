using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField]
    private Button[] lvlButtons;

    private void Start()
    {
        int levelAt = PlayerPrefs.GetInt("highestLvlUnlock", 1);

        for (int i = 1; i < lvlButtons.Length + 1; i++)
        {
            if (i > levelAt)
            {
                lvlButtons[i - 1].interactable = false;
            }
        }
    }
}
