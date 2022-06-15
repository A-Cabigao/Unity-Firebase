using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerValidation : MonoBehaviour
{
    private ButtonText buttonText;
    private bool isWrongAnswer = false;

    private void Awake()
    {
        buttonText = FindObjectOfType<ButtonText>();
    }

    public void AnswerClicked(int index)
    {
        CheckAnswer(index);

        if(!isWrongAnswer)
        {
            ScoreManager.instance.currentQuestionIndex++;
            ScoreManager.instance.OnQuestionProceed?.Invoke();
        }
    }

    private void CheckAnswer(int index)
    {
        if (index != buttonText.answerIndex)
        {
            isWrongAnswer = true;
            GameManager.instance.OnGameEnd?.Invoke();
        }
        else
            ScoreManager.instance.IncreaseScore();
    }
}
