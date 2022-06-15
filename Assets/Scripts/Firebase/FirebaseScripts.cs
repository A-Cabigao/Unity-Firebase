using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using TMPro;

public class FirebaseScripts : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI statusText;
    [SerializeField]
    private TextMeshProUGUI infoText;

    public static FirebaseScripts instance;

    private Player player = null;

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

    public void PutToDatabase(Player player)
    {
        RestClient.Put("https://unity-with-firebase-6f4d2-default-rtdb.firebaseio.com/Players/" +player.playerName+ ".json", player);
        statusText.text = "Put success!";
    }

    public void GetFromDatabase(string name)
    {
        GetPlayerFromDatabase(name);     
    }

    private void GetPlayerFromDatabase(string name)
    {
        RestClient.Get<Player>("https://unity-with-firebase-6f4d2-default-rtdb.firebaseio.com/Players/" + name + ".json").
           Then(onResolved: response => { player = response; ChangeText(); }, 
           onRejected: response => { player = null; ChangeText(); });
    }

    private void ChangeText()
    {
        if (player != null)
        {
            statusText.text = "<color=green>Player found!</color>";
            infoText.text = "Name: " + player.playerName
                + "\nScore: " + player.playerScore;
            player = null;
        }
        else
            statusText.text = "<color=red>No player found!</color>";
    }
}
