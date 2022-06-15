using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Action OnChangeScore;
    public Action OnQuestionProceed;

    [HideInInspector]
    public int currentQuestionIndex = 0;
    private int _score = 0;

    public int Score 
    { 
        get { return _score; }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            DestroyImmediate(instance);
            instance = this;
        }    
    }

    public void IncreaseScore()
    {
        _score++;
        OnChangeScore?.Invoke();
    }
}
