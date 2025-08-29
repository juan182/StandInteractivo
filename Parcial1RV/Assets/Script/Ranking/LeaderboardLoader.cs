using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Player
{
    public string name;
    public string email;
    public int age;
    public string city;
    public int score; // Coincide con el JSON
}

[System.Serializable]
public class PlayerDataWrapper
{
    public List<Player> playerList; // Coincide con el JSON
}

public class LeaderboardLoader : MonoBehaviour
{
    [Header("Ruta del archivo")]
    private string filePath;

    [Header("Referencias de TextMeshPro")]
    public TMP_Text[] nameTexts;  // 5 elementos
    public TMP_Text[] scoreTexts; // 5 elementos

    private void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "playerData.json");
    }

    public void ShowTopPlayers()
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError("No se encontró el archivo en: " + filePath);
            return;
        }

        string json = File.ReadAllText(filePath);
        if (string.IsNullOrEmpty(json))
        {
            Debug.LogError("El archivo JSON está vacío.");
            return;
        }

        PlayerDataWrapper data = JsonUtility.FromJson<PlayerDataWrapper>(json);

        if (data == null || data.playerList == null || data.playerList.Count == 0)
        {
            Debug.LogError("No hay datos válidos en el archivo.");
            return;
        }

        // Ordenar por puntaje descendente
        data.playerList.Sort((a, b) => b.score.CompareTo(a.score));

        // Mostrar los 5 mejores
        for (int i = 0; i < 5; i++)
        {
            if (i < data.playerList.Count)
            {
                nameTexts[i].text = data.playerList[i].name;
                scoreTexts[i].text = data.playerList[i].score.ToString();
            }
            else
            {
                nameTexts[i].text = "-";
                scoreTexts[i].text = "-";
            }
        }

        Debug.Log("Leaderboard actualizado con los 5 mejores jugadores.");
    }
}
