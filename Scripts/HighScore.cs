using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HighScore : MonoBehaviour
{
    public Score scor;
    public float HighScoreValue;
    public float CurrentScore;
    public TextMeshProUGUI Text;
    private void Start()
    {
        HighScoreValue = PlayerPrefs.GetFloat("HighScore",0);
        Text.text = HighScoreValue.ToString();
    }
    private void Update()
    {
        CurrentScore = scor.score;
    }
    public void dead()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PauseMenu.instance.canPause = false;
        if (CurrentScore>HighScoreValue)
        {
            PlayerPrefs.SetFloat("HighScore", scor.score);
            HighScoreValue = PlayerPrefs.GetFloat("HighScore");
        }
        Text.text = "Highscore: " + HighScoreValue.ToString("#");
    }
}
