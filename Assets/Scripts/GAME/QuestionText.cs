using UnityEngine;
using TMPro;

public class QuestionText : MonoBehaviour
{
    private TextMeshProUGUI questionText;
    private GameLogic gameLogic;

    private void Awake()
    {
        gameLogic = FindObjectOfType<GameLogic>();
        questionText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        ChangeQuestionText();
    }

    private void OnEnable()
    {
        ScoreManager.instance.OnQuestionProceed += ChangeQuestionText;
    }

    private void OnDisable()
    {
        ScoreManager.instance.OnQuestionProceed -= ChangeQuestionText;
    }

    private void ChangeQuestionText()
    {
        Debug.Log(gameLogic.GetAnswer(ScoreManager.instance.currentQuestionIndex));
        questionText.text = string.Format
            ("{0} {1} {2}", 
            gameLogic.GetGeneratedNumber(0, ScoreManager.instance.currentQuestionIndex),
            gameLogic.GetArithmetic(ScoreManager.instance.currentQuestionIndex),
            gameLogic.GetGeneratedNumber(1, ScoreManager.instance.currentQuestionIndex));
    }
}
