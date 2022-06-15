using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        ScoreManager.instance.OnChangeScore += ChangeScoreText;
    }

    private void OnDisable()
    {
        ScoreManager.instance.OnChangeScore -= ChangeScoreText;
    }

    private void ChangeScoreText()
    {
        scoreText.text = "Score: " + ScoreManager.instance.Score;
    }
}
