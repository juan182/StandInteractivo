using UnityEngine;

public class SpecialPoint : MonoBehaviour
{
    [Header("Puntos que suma este objeto")]
    public int valor = 1; // Ajusta en el inspector

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detectar colisión con el Player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Sumar puntos al GameManager
            if (GameManager.Instance != null)
            {
                GameManager.Instance.sumPoint(valor);
            }

            // Destruir este objeto
            Destroy(gameObject);
        }
    }
}

