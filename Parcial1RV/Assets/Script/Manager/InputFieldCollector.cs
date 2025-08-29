using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InputFieldCollector : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField emailField;
    public TMP_InputField ageField;
    public TMP_InputField cityField;

    // Nombre de la escena de juego
    public string sceneToLoad;

    public void CollectAndGo()
    {
        // Buscar UIDataCollector persistente
        UIDataCollector uiCollector = FindFirstObjectByType<UIDataCollector>();

        if (uiCollector != null)
        {
            int age = int.TryParse(ageField.text, out int parsedAge) ? parsedAge : 0;

            // Enviar los datos a UIDataCollector
            uiCollector.SaveTempData(
                nameField.text,
                emailField.text,
                age,
                cityField.text
            );

            Debug.Log("Datos enviados a UIDataCollector: " + nameField.text);
        }
        else
        {
            Debug.LogError("No se encontró UIDataCollector en la escena.");
        }

        // Cambiar a la escena del juego
        SceneManager.LoadScene(sceneToLoad);
    }
}
