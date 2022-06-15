using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonText : MonoBehaviour
{
    private GameLogic gameLogic;
    private List<TextMeshProUGUI> buttonTexts = new List<TextMeshProUGUI>();

    public int answerIndex { get; private set; }

    private void Awake()
    {
        foreach (TextMeshProUGUI child in transform.GetComponentsInChildren<TextMeshProUGUI>())
            buttonTexts.Add(child);

        gameLogic = FindObjectOfType<GameLogic>();
    }

    private void OnEnable()
    {
        ScoreManager.instance.OnQuestionProceed += ChangeTexts;
    }

    private void OnDisable()
    {
        ScoreManager.instance.OnQuestionProceed -= ChangeTexts;
    }

    private void Start()
    {
        ChangeTexts();
    }

    public void ChangeTexts()
    {
        int rand = Random.Range(0, 4);
        int answer = gameLogic.GetAnswer(ScoreManager.instance.currentQuestionIndex);
        answerIndex = rand;

        for(int i = 0; i < buttonTexts.Count; i++)
        {
            if (i == rand)
                buttonTexts[i].text = answer.ToString();
            else
                buttonTexts[i].text = (answer + Random.Range(3, 12)).ToString();
        }
    }

}
