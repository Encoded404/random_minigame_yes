using UnityEngine;
using TMPro;

public static class ScoreManager
{
    private static int redTeamScore = 0;
    private static int greenTeamScore = 0;

    private static TMP_Text scoreText;

    public static void Initialize(TMP_Text textComponent)
    {
        scoreText = textComponent;
        UpdateScoreText();
    }

    public static void AddToRedTeamScore(int amount)
    {
        redTeamScore += amount;
        UpdateScoreText();
    }

    public static void AddToGreenTeamScore(int amount)
    {
        greenTeamScore += amount;
        UpdateScoreText();
    }

    private static void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Red-Team Score: " + redTeamScore + "\nGreen-Team Score: " + greenTeamScore;
        }
    }
}
