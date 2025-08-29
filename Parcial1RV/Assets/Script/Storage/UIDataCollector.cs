using UnityEngine;

public class UIDataCollector : MonoBehaviour
{
    // Variables temporales para guardar datos de Escena 1
    private string playerName;
    private string playerEmail;
    private int playerAge;
    private string playerCity;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // Persistente entre escenas
    }

    // Guardar datos del jugador desde los InputFields en Escena 1
    public void SaveTempData(string name, string email, int age, string city)
    {
        playerName = name;
        playerEmail = email;
        playerAge = age;
        playerCity = city;
        Debug.Log("Datos temporales guardados: " + playerName);
    }

    // Guardar los datos finales con puntos en Escena 2
    public void SavePlayerData(int score)
    {
        if (string.IsNullOrEmpty(playerName))
        {
            Debug.LogError("No se han guardado los datos del jugador.");
            return;
        }

        if (DataStorage.Instance != null)
        {
            DataStorage.Instance.AddNewData(playerName, playerEmail, playerAge, playerCity, score);
            Debug.Log("Datos finales guardados: " + playerName + " con puntos: " + score);
        }
    }
}
