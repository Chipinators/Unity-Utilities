using System;
using UnityEngine;
using Chipinators;

public class FileSaverExamples : MonoBehaviour
{
    public PlayerData playerData;
    void Awake()
    {
        LoadPlayerData();
    }

    void OnApplicationQuit()
    {
        SavePlayerData(playerData);
    }

    public void SavePlayerData(PlayerData data)
    {
        FileSaver.Save(PlayerData.FileName, data);
    }

    public void LoadPlayerData()
    {
        playerData = FileSaver.Load<PlayerData>(PlayerData.FileName);
    }
    
    public void ResetPlayerData()
    {
        FileSaver.Delete(PlayerData.FileName);
    }
}

/// <summary>
/// Any class you want to save as a file must be maked as Serializable.
/// </summary>
[Serializable]
public class PlayerData
{
    /// <summary>
    /// Returns PlayerData.dat, this is an easy to make sure you don't mess up file names between save/load.
    /// </summary>
    public static string FileName { get => typeof(PlayerData) + ".dat"; }

    public string username;
    public int currency;
    public int highScore;
    public DateTime lastPlayTime;
}