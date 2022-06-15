using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Proyecto26;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    
    public TMP_InputField playerInput;

    public static int playerScore;
    public static string playerName;

    private void Start()
    {
        playerScore = Random.Range(1, 101);
        scoreText.text = "Score: " + playerScore.ToString();
    }

    public void OnSubmit()
    {
        playerName = playerInput.text;
        PostToDatabase();
    }

    public void GetScore()
    {

    }

    private void PostToDatabase()
    {
        User user = new User();
        RestClient.Put("https://unity-with-firebase-6f4d2-default-rtdb.firebaseio.com/" + playerName+ ".json", user);
    }

    private void RetrieveFromDatabase()
    {
        
    }
}
