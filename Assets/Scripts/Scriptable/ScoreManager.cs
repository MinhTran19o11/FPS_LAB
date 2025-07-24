using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public ScoreData playerScoreData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void IncreaseScore(int amount)
    {
        playerScoreData.playerScore += amount;
        Debug.Log("Score increased by " + amount + ". New score: " + playerScoreData.playerScore);
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("PlayerScore", playerScoreData.playerScore);
        PlayerPrefs.Save();
    }

    public void LoadScore()
    {
        playerScoreData.playerScore = PlayerPrefs.GetInt("PlayerScore", 0);
    }
}
