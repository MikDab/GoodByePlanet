using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text scoreText;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    public void AddToScore(int amount)
    {
        score += amount;
        UpdateScore();
    }

    public void ReduceScore(int amount)
    {
        score -= amount;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString() + " :Score";
    }
}
