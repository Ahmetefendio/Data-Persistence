using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoresText;
    void Start()
    {
        string text = "";
        for (int i = 0; i < MenuManager.Instance.data.highScoreTable.Count; i++)
        {
            text += (i+1) + ". " + MenuManager.Instance.data.highScoreTable[i].PlayerName + " " + MenuManager.Instance.data.highScoreTable[i].Score + "\n";
        }

        scoresText.text = text;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
