// Ailand Parriott
// created: 23.04.21
//
// This script adds functionality to the score


using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreController : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    

    void Start()
    {
        score = 0;
        UpdateScore();
    }

    public void AddScore(int scoreAdd)
    {
        score += scoreAdd;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
}
