using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    [Header("Objetos a spawnear")]
    public GameObject[] objetosASpawnear; // Array con tus 2 prefabs

    [Header("Puntos de Spawn (a-e)")]
    public Transform[] puntosSpawn; // Array de 5 posiciones vacías

    [Header("Configuración de Spawn")]
    public float tiempoMin = 2f; // Tiempo mínimo para volver a permitir spawn en ese punto
    public float tiempoMax = 5f; // Tiempo máximo para volver a permitir spawn en ese punto
    public float tiempoVida = 10f; // Tiempo antes de destruir el objeto

    private bool[] puedeSpawnear; // Controla si cada punto puede spawnear

    void Start()
    {
        puedeSpawnear = new bool[puntosSpawn.Length];

        // Inicializa todos los puntos como disponibles y lanza el spawn
        for (int i = 0; i < puntosSpawn.Length; i++)
        {
            puedeSpawnear[i] = true;
            StartCoroutine(SpawnEnPunto(i));
        }
    }

    IEnumerator SpawnEnPunto(int index)
    {
        while (true) // Bucle infinito para cada punto
        {
            if (puedeSpawnear[index])
            {
                puedeSpawnear[index] = false;

                // Seleccionar objeto aleatorio
                GameObject objeto = objetosASpawnear[Random.Range(0, objetosASpawnear.Length)];

                // Instanciar en el punto
                GameObject instancia = Instantiate(objeto, puntosSpawn[index].position, Quaternion.identity);

                // Destruir el objeto después de tiempoVida segundos
                Destroy(instancia, tiempoVida);

                // Esperar un tiempo aleatorio antes de permitir otro spawn
                float espera = Random.Range(tiempoMin, tiempoMax);
                yield return new WaitForSeconds(espera);

                puedeSpawnear[index] = true;
            }

            // Pequeño delay para evitar sobrecarga
            yield return null;
        }
    }
}

