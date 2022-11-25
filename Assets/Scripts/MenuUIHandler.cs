using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        if (MenuManager.Instance.data.highScoreTable.Count != 0)
        {
            scoreText.text = "Best Score : " + MenuManager.Instance.data.highScoreTable[0].PlayerName + " " + MenuManager.Instance.data.highScoreTable[0].Score;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetName(string name)
    {
        MenuManager.Instance.player.PlayerName = name;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void HighScoreTable()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
        MenuManager.Instance.SaveScoreList();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif

    }
}
