using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;
    private void OnEnable() => EnemyCore.giveScore += UpdateScore;
    private void OnDisable() => EnemyCore.giveScore -= UpdateScore;
    private void Start()
    {
        UpdateScore(score);
    }
    private void UpdateScore(int addedScore)
    {
        score += addedScore;
        scoreText.text = "Score: " + score;
    }
}
