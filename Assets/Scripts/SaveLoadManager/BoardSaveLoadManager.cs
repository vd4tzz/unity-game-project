using System;
using System.Collections.Generic;
using System.IO;
using BoardEnemy;
using UnityEngine;

public class BoardSaveLoadManager<T> : MonoBehaviour where T : BoardController
{
    string directoryName = "SaveGame";
    protected string boardSaveFile;
    string dirPath;
    string path;

    protected virtual void Awake()
    {
        dirPath = Path.Combine(Application.dataPath, directoryName);
        path = Path.Combine(dirPath, boardSaveFile);
        Debug.Log(path);
    }

    protected virtual void Start()
    {
        if(Directory.Exists(dirPath) == false)
        {
            Directory.CreateDirectory(dirPath);
        }
    }

    
    protected virtual void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
        }
    }

    public void SaveGame()
    {
        T[] boards = FindObjectsOfType<T>();
        List<BoardSaveData> list = new List<BoardSaveData>();
        foreach(T board in boards)
        {
            BoardSaveData data = new BoardSaveData();
            data.spawPoint = board.SpawnPoint;
            list.Add(data);
        }

        string json = JsonUtility.ToJson(new BoardSaveDataList { dataList = list }, true);
        
        File.WriteAllText(path, json);

        Debug.Log(path);
    }

    public void LoadGame()
    { 
        BoardSaveDataList boardSaveDataList;

        string json = File.ReadAllText(path);   
        boardSaveDataList = JsonUtility.FromJson<BoardSaveDataList>(json);
        List<BoardSaveData> list = boardSaveDataList.dataList;

        T[] boards = FindObjectsOfType<T>();
        int n = list.Count;
        int i = 0;
        for(; i < n; i++)
        {
            boards[i].transform.position = list[i].spawPoint;
            boards[i].SpawnPoint = list[i].spawPoint;
        }

        for(; i < boards.Length; i++)
        {
            if(boards[i].gameObject != null)
                Destroy(boards[i].gameObject);
        }

        
    }

}

[Serializable]
public class BoardSaveData
{
    public Vector3 spawPoint;
}

[Serializable]
public class BoardSaveDataList
{
    public List<BoardSaveData> dataList;
}
