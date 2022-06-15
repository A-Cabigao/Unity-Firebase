using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    private GameObject gameCanvas;
    [SerializeField]
    private GameObject endgameCanvas;

    private void OnEnable()
    {
        GameManager.instance.OnGameEnd += EnableEndGame;
    }

    private void OnDisable()
    {
        GameManager.instance.OnGameEnd -= EnableEndGame;
    }

    private void EnableEndGame()
    {
        gameCanvas.SetActive(false);
        endgameCanvas.SetActive(true);
    }

    public void SubmitToFirebase(string playerName)
    {
        Player player = new Player(ScoreManager.instance.Score, playerName);
        FirebaseScripts.instance.PutToDatabase(player);
    }
}
