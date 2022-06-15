using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonValue : MonoBehaviour
{
    private TextMeshProUGUI buttonText;

    private void Awake()
    {
        buttonText = GetComponent<TextMeshProUGUI>();
    }

    public void ChangeText(string value)
    {
        buttonText.text = value;
    }
}
