using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SearchButton : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputField;

    public void GetData()
    {
        FirebaseScripts.instance.GetFromDatabase(inputField.text);
        inputField.text = string.Empty;
    }
}
