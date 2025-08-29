using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataStorage : MonoBehaviour
{
    public static DataStorage Instance;
    public List<PlayerData> playerDataList = new List<PlayerData>();
    private string filePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Ruta segura y accesible en cualquier plataforma
            filePath = Path.Combine(Application.persistentDataPath, "playerData.json");

            if (File.Exists(filePath))
                LoadDataFromJson();
            else
                SaveDataToJson(); // crear JSON vacío si no existe
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddNewData(string name, string email, int age, string city, int score)
    {
        PlayerData newPlayer = new PlayerData(name, email, age, city, score);
        playerDataList.Add(newPlayer);
        SaveDataToJson();
    }

    public void SaveDataToJson()
    {
        string json = JsonUtility.ToJson(new PlayerListWrapper(playerDataList), true);
        File.WriteAllText(filePath, json);
        Debug.Log("JSON guardado en: " + filePath);

        if (File.Exists(filePath))
            Debug.Log("¡Archivo confirmado! El JSON existe.");
        else
            Debug.LogError("El archivo JSON NO se creó.");
    }

    public void LoadDataFromJson()
    {
        string json = File.ReadAllText(filePath);
        PlayerListWrapper wrapper = JsonUtility.FromJson<PlayerListWrapper>(json);
        if (wrapper != null)
            playerDataList = wrapper.playerList;
    }

    // Método opcional para ver el contenido del JSON en la consola
    public void PrintJson()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Debug.Log("Contenido del JSON:\n" + json);
        }
        else
        {
            Debug.LogError("No existe JSON para mostrar.");
        }
    }

    public string GetFilePath()
    {
        return filePath;
    }
}

[System.Serializable]
public class PlayerListWrapper
{
    public List<PlayerData> playerList;

    public PlayerListWrapper(List<PlayerData> list)
    {
        playerList = list;
    }
}
