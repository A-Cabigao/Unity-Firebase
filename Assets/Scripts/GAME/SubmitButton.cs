using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubmitButton : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputField;

    private EndGame endgame;

    private void Awake()
    {
        endgame = FindObjectOfType<EndGame>();    
    }

    public void SetName()
    {
        string name = inputField.text;
        endgame.SubmitToFirebase(name);
        inputField.text = string.Empty;
    }


}
