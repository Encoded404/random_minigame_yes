using UnityEngine;
using TMPro;

public class SpaceInvaderScore : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        ScoreManager.Initialize(scoreText);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ScoreManager.AddToRedTeamScore(1);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            ScoreManager.AddToGreenTeamScore(1);
        }
    }
}
