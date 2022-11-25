using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public PlayerInfo player;
    public SaveData data;
    public List<PlayerInfo> highScoreTable = new List<PlayerInfo>();

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code
        Instance = this;
        DontDestroyOnLoad(gameObject);
        data = new SaveData();
        LoadScoreList();
    }

    void Start()
    {
        player = new PlayerInfo();
    }


    public void AddToHighScore()
    {
        PlayerInfo savePlayerInfo = new PlayerInfo();
        savePlayerInfo.PlayerName = player.PlayerName;
        savePlayerInfo.Score = player.Score;

        if(data.highScoreTable.Count == 0)
        {
            data.highScoreTable.Add(savePlayerInfo);
            //highScoreTable.Add(player);
        }
        else
        {
            for (int i = 0; i < data.highScoreTable.Count; i++)
            {
                if (player.Score > data.highScoreTable[i].Score)
                {
                    data.highScoreTable.Insert(i, savePlayerInfo);
                    break;
                    //highScoreTable.Insert(i, player);
                }
                if (data.highScoreTable.Count < 10 && i == data.highScoreTable.Count-1)
                {
                    data.highScoreTable.Add(savePlayerInfo);
                    //highScoreTable.Add(player);
                }
            }
            
        }

    }
    
    public void SaveScoreList()
    {

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        Debug.Log("Save List");
        printList();
    }

    public void LoadScoreList()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("Load List");
            printList();
        }
        
    }

    public void printList()
    {
        for (int i = 0; i < data.highScoreTable.Count; i++)
        {
            Debug.Log(data.highScoreTable[i].PlayerName);
            Debug.Log(data.highScoreTable[i].Score);
        }
    }



}
