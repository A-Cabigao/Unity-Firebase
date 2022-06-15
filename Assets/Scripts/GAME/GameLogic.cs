using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    private List<int> randomGeneratedNumbersA = new List<int>();
    private List<int> randomGeneratedNumbersB = new List<int>();
    private List<int> randomArtihmetic = new List<int>();

    private List<int> answers = new List<int>();

    public int GetAnswer (int index)
    {
        if (index >= answers.Count)
            return 0;
        else
            return answers[index];
    }

    public int GetGeneratedNumber(int group, int index)
    {
        if (index > randomGeneratedNumbersA.Count)
            return 0;

        if (group == 0)
        {
            return randomGeneratedNumbersA[index];
        }
        else if (group == 1)
        {
            return randomGeneratedNumbersB[index];
        }
        else
            return 0;
    }

    public char GetArithmetic(int index)
    {
        if (index > randomArtihmetic.Count)
            return 'n';
        else
        {
            switch (randomArtihmetic[index])
            {
                case 0:
                    return '+';
                case 1:
                    return '-';
                case 2:
                    return '*';
                default:
                    return 'n';
            }
        }
    }

    private void Start()
    {
        PopulateLists();
        CalculateAnswers();
    }

    private void OnEnable()
    {
        ScoreManager.instance.OnQuestionProceed += AddToLists;
    }

    private void OnDisable()
    {
        ScoreManager.instance.OnQuestionProceed -= AddToLists;
    }

    private void PopulateLists()
    {
        for (int i = 0; i <= 10; i ++)
        {
            randomGeneratedNumbersA.Add(Random.Range(0, 101));
            randomGeneratedNumbersB.Add(Random.Range(0, 101));
            randomArtihmetic.Add(Random.Range(0, 3));
        }
    }

    public void AddToLists()
    {
        int varA = Random.Range(0, 101);
        int varB = Random.Range(0, 101);
        int arithmetic = Random.Range(0, 3);

        randomGeneratedNumbersA.Add(varA);
        randomGeneratedNumbersB.Add(varB);
        randomArtihmetic.Add(arithmetic);

        CalculateNewAnswer(varA, varB, arithmetic);
    }

    private void CalculateAnswers()
    {
        for(int i = 0; i < randomGeneratedNumbersA.Count; i++)
        {
            switch(randomArtihmetic[i])
            {
                case 0:
                    answers.Add(randomGeneratedNumbersA[i] + randomGeneratedNumbersB[i]);
                    break;
                case 1:             
                    answers.Add(Subtraction(randomGeneratedNumbersA[i], randomGeneratedNumbersB[i], i));                 
                    break;
                case 2:
                    answers.Add(randomGeneratedNumbersA[i] * randomGeneratedNumbersB[i]);
                    break;
            }
        }
    }

    private void CalculateNewAnswer(int varA, int varB, int arithmetic)
    {
        int currentListCount = randomGeneratedNumbersA.Count - 1;
        switch (arithmetic)
        {
            case 0:
                answers.Add(varA + varB);
                break;
            case 1:
                answers.Add(Subtraction(varA, varB, currentListCount));
                break;
            case 2:
                answers.Add(varA * varB);
                break;
        }
    }

    private int Subtraction(int a, int b, int index)
    {
        if (a <= b)
        {
            b = a;
            a = b;

            randomGeneratedNumbersA[index] = b;
            randomGeneratedNumbersB[index] = a;
        }
        return a - b;
    }
}
