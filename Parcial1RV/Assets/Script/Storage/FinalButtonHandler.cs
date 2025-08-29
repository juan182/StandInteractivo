using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalButtonHandler : MonoBehaviour
{
    public string sceneToLoad = "Scene1"; // Escena inicial

    public void SaveAndReturn()
    {
        // Buscar UIDataCollector persistente
        UIDataCollector dataCollector = FindFirstObjectByType<UIDataCollector>();

        if (dataCollector != null)
        {
            int finalScore = GameManager.Instance.Point;
            dataCollector.SavePlayerData(finalScore);

            // Reiniciar puntos después de guardar
            GameManager.Instance.Reset();
            Debug.Log("Puntos reiniciados a 0.");
        }

        SceneManager.LoadScene(sceneToLoad);
    }
}
