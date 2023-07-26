using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreText;
    [SerializeField] TMP_Text HighscoreText;

    public int currentScore { get; private set; } = 0;

    public void OnUnitDeath()
    {
        currentScore += 1;
        ScoreText.text = $"Score: {currentScore}";
    }

    public void OnPlayerDeath()
    {
        int highscore = PlayerPrefs.GetInt("highscore", 0);
        if(currentScore > highscore)
        {
            highscore = currentScore;
            PlayerPrefs.SetInt("highscore", currentScore);
        }

        HighscoreText.text = $"Highscore: {highscore}";
    }

    public void SetScore(int score)
    {
        currentScore = score;
        ScoreText.text = $"Score: {currentScore}";
    }    
}
