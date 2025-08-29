using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Configuración del Juego")]
    public float tiempoLimite = 45f;   // Tiempo antes de pausar el juego
    public float incrementoVelocidad = 0.05f; // Aumento de velocidad cada segundo
    public float velocidadMaxima = 2f; // Límite máximo de Time.timeScale

    [Header("UI")]
    public GameObject panelFinal;  // Panel que aparecerá cuando acabe el tiempo
    public TextMeshPro textoTiempo;       // Texto opcional para mostrar el tiempo

    private float tiempoActual;    // Contador interno
    private bool juegoPausado = false;
    private PlayerController player;

    void Start()
    {
        tiempoActual = 0f;
        Time.timeScale = 1f; // Velocidad inicial normal
        if (panelFinal != null) panelFinal.SetActive(false);

        // Buscar automáticamente al Player
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.GetComponent<PlayerController>();
        }
    }

    void Update()
    {
        if (juegoPausado) return; // Si ya está pausado, no seguir

        // Si la salud del jugador llega a 0, pausar juego
        if (player != null && player.health <= 0)
        {
            PausarJuego();
            return;
        }

        // Incrementar cronómetro
        tiempoActual += Time.deltaTime;

        // Aumentar velocidad progresiva
        if (Time.timeScale < velocidadMaxima)
        {
            Time.timeScale += incrementoVelocidad * Time.deltaTime;
        }

        // Actualizar texto UI
        if (textoTiempo != null)
        {
            textoTiempo.text = "Tiempo: " + Mathf.FloorToInt(tiempoActual).ToString();
        }

        // Si se alcanza el tiempo límite, pausar juego
        if (tiempoActual >= tiempoLimite)
        {
            PausarJuego();
        }
    }

    void PausarJuego()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        if (panelFinal != null) panelFinal.SetActive(true);
    }

    // Llamar este método cuando el Player choque con un objeto "Tree"
    public void PlayerTocoArbol()
    {
        PausarJuego();
    }
}
